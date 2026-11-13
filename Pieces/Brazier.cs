using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static BuildPiece brazier;
    private static bool brazier_loaded;
    private static void SetupBrazier()
    {
        brazier = new BuildPiece("white_castle_bundle", "piece_white_marble_brazier");
        brazier.Name.English("Brazier");
        brazier.Description.English("");
        brazier.Category.Set("White Castle");
        brazier.Usage.Set(Piece.UsageTagFlags.Lighting);
        brazier.RequiredItems.Add("Ice", 1, true);
        brazier.Snapshot();

        var piece = brazier.Prefab.GetComponent<Piece>();
        var wnt = brazier.Prefab.GetComponent<WearNTear>();
            
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_metal");
        wnt.m_destroyedEffect = new EffectListRef( "sfx_metal_blocked");
        wnt.m_hitEffect = new EffectListRef("vfx_HitSparks");
    }

    public static void LoadBrazierAssets()
    {
        if (brazier_loaded) return;
        if (PrefabManager.TryGetPrefab("Morkhalla_firepit", out var Morkhalla_firepit))
        {
            SetupCoalMesh(Morkhalla_firepit, brazier.Prefab);
            SetupSfx(Morkhalla_firepit, brazier.Prefab);
            SetupParticles(Morkhalla_firepit, brazier.Prefab);
            SetupFireplace(Morkhalla_firepit, brazier.Prefab);
        }

        if (PrefabManager.TryGetPrefab("fire_pit", out var fire_pit) && 
            fire_pit.TryGetComponent(out Fireplace component) && 
            brazier.Prefab.TryGetComponent(out Fireplace fireplace))
        {
            fireplace.m_snowMelter = component.m_snowMelter;
            fireplace.m_snowMelterInterval = component.m_snowMelterInterval;
            fireplace.m_fireworkItemList = component.m_fireworkItemList;
            fireplace.m_firePrefab = component.m_firePrefab;
        }
        brazier_loaded = true;
    }

    private static void SetupFireplace(GameObject source, GameObject target)
    {
        if (source.TryGetComponent(out Fireplace sFireplace) && target.TryGetComponent(out Fireplace tFireplace))
        {
            tFireplace.m_fuelItem = sFireplace.m_fuelItem;
            tFireplace.m_fuelAddedEffects = sFireplace.m_fuelAddedEffects;
        }
    }

    private static void SetupCoalMesh(GameObject source, GameObject target)
    {
        var coals = target.transform.Find("coals");
        var coal = source.transform.Find("New/model");
        var colliderSharedMesh = source.transform.Find("New/collider").GetComponent<MeshCollider>().sharedMesh;
        if (coal.TryGetComponent(out MeshFilter f) && coal.TryGetComponent(out MeshRenderer r))
        {
            for (int i = 0; i < coals.childCount; ++i)
            {
                var child = coals.GetChild(i);
                if (child.TryGetComponent(out MeshFilter filter) && child.TryGetComponent(out MeshRenderer renderer))
                {
                    filter.sharedMesh = f.sharedMesh;
                    renderer.sharedMaterials = r.sharedMaterials;
                }

                if (child.TryGetComponent(out MeshCollider collider))
                {
                    collider.sharedMesh = colliderSharedMesh;
                }
            }
                
        }
    }
    
    private static void SetupSfx(GameObject source, GameObject target)
    {
        var sfx = source.transform.Find("_enabled_high/sfx_fire_loop");
        var s = target.transform.Find("_enabled_high/sfx_fire_loop");

        s.GetComponent<ZSFX>().m_audioClips = sfx.GetComponent<ZSFX>().m_audioClips;
        s.GetComponent<AudioSource>().outputAudioMixerGroup = sfx.GetComponent<AudioSource>().outputAudioMixerGroup;
    }

    private static void SetupParticles(GameObject source, GameObject target)
    {
        var sP = source.transform.Find("_enabled_high/Particles");
        var tP = target.transform.Find("_enabled_high/Particles");

        for (int i = 0; i < sP.childCount; ++i)
        {
            var sChild = sP.GetChild(i);
            var tChild = tP.GetChild(i);
            if (sChild.TryGetComponent(out Renderer sR) && tChild.TryGetComponent(out Renderer tR))
            {
                tR.sharedMaterials = sR.sharedMaterials;
            }
        }

        target.transform
            .Find("_enabled_low/smok_small")
            .GetComponent<Renderer>()
            .sharedMaterials = 
            source.transform
                .Find("_enabled_low/smok_small")
                .GetComponent<Renderer>()
                .sharedMaterials;
    }
}
