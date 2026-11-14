using System;
using HarmonyLib;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static void SetupBell()
    {
        var build = new BuildPiece("white_castle_bundle", "piece_white_marble_bell");
        build.Name.English("Golden Bell");
        build.Description.English("");
        build.Category.Set("White Castle");
        build.Usage.Set(Piece.UsageTagFlags.Decor);
        build.RequiredItems.Add("Gold", 10, true);
        build.Crafting.Set(CraftingTable.BlackForge);
        build.Snapshot();

        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
            
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_metal");
        wnt.m_destroyedEffect = new EffectListRef( "sfx_metal_blocked");
        wnt.m_hitEffect = new EffectListRef("vfx_HitSparks", "sfx_fader_bell");
        wnt.m_health = 5000;

        build.Prefab.AddComponent<Bell>();
    }    
}

public class Bell : MonoBehaviour
{
    public ZNetView m_nview;
    public Transform m_waist;
    public Transform m_clapper;

    public Vector3 m_rotationAxis = Vector3.right;

    public float m_swingFrequency = 1.2f; 
    public float m_swingDamping = 0.08f;   
    public float m_forcePerDamage = 1.5f;   
    public float m_minKick = 40f;
    public float m_maxKick = 180f;
    public float m_maxAngle = 35f;

    public float m_clapperFrequency = 1.2f;
    public float m_clapperDamping = 0.1f;
    public float m_clapperFollow = 1.6f;
    public float m_maxClapperAngle = 23f;

    private Quaternion m_waistRest;
    private Quaternion m_clapperRest;
    private Vector3 m_axis;

    private float m_angle;
    private float m_velocity;
    private float m_clapperAngle;
    private float m_clapperVelocity;

    public void Awake()
    {
        m_nview = GetComponent<ZNetView>();
        
        m_waist = transform.Find("waist");
        m_clapper = transform.Find("waist/yoke/clapper");

        if (m_waist)
        {
            m_waistRest = m_waist.localRotation;
        }
        if (m_clapper)
        {
            m_clapperRest = m_clapper.localRotation;
        }

        m_axis = m_rotationAxis.normalized;

        if (m_nview.GetZDO() != null)
        {
            m_nview.Register<float>(nameof(RPC_SetBellVelocity), RPC_SetBellVelocity);
        }
    }

    public void RPC_SetBellVelocity(long sender, float velocity)
    {
        m_velocity += velocity;
        m_clapperVelocity -= velocity * 1.5f;
    }

    public void ApplyForce(HitData hit)
    {
        if (!m_waist) return;

        Vector3 dir = m_waist.position - hit.m_point;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.0001f)
        {
            dir = hit.m_dir;
            dir.y = 0f;
        }
        if (dir.sqrMagnitude < 0.0001f) return;

        Vector3 localDir = m_waist.InverseTransformDirection(dir.normalized);
        Vector3 positiveSwing = Vector3.Cross(m_axis, Vector3.down);

        float along = Vector3.Dot(localDir, positiveSwing);
        if (Mathf.Abs(along) < 0.05f) return; 

        float kick = Mathf.Clamp(hit.GetTotalDamage() * m_forcePerDamage, m_minKick, m_maxKick);
        float signed = kick * Mathf.Sign(along);
        
        m_nview.InvokeRPC(ZNetView.Everybody, nameof(RPC_SetBellVelocity), signed);
    }
    
    private void Update()
    {
        if (!m_waist) return;
        if (Mathf.Abs(m_velocity) < 0.01f && 
            Mathf.Abs(m_angle) < 0.01f &&
            Mathf.Abs(m_clapperVelocity) < 0.01f && 
            Mathf.Abs(m_clapperAngle) < 0.01f)
            return;

        float dt = Mathf.Min(Time.deltaTime, 0.033f);

        Step(ref m_angle, ref m_velocity, 0f, m_swingFrequency, m_swingDamping, dt);
        m_angle = Mathf.Clamp(m_angle, -m_maxAngle, m_maxAngle);

        Step(ref m_clapperAngle, ref m_clapperVelocity, -m_angle * m_clapperFollow,
            m_clapperFrequency, m_clapperDamping, dt);
        m_clapperAngle = Mathf.Clamp(m_clapperAngle, -m_maxClapperAngle, m_maxClapperAngle);

        m_waist.localRotation = m_waistRest * Quaternion.AngleAxis(m_angle, m_axis);
        if (m_clapper)
        {
            m_clapper.localRotation = m_clapperRest * Quaternion.AngleAxis(m_clapperAngle, m_axis);
        }
    }

    private static void Step(
        ref float angle, 
        ref float velocity, 
        float target,
        float frequency, 
        float damping, 
        float dt)
    {
        float w = 2f * Mathf.PI * frequency;
        float accel = (target - angle) * (w * w) - velocity * (2f * damping * w);
        velocity += accel * dt;
        angle += velocity * dt;
    }

    [HarmonyPatch(typeof(WearNTear), nameof(WearNTear.RPC_Damage))]
    private static class WearNTear_RPC_Damage_Bell_Patch
    {
        private static void Postfix(WearNTear __instance, HitData hit)
        {
            if (!__instance.m_nview.IsValid() || !__instance.m_nview.IsOwner() || !__instance.TryGetComponent(out Bell component)) return;
            component.ApplyForce(hit);
        }
    }
}