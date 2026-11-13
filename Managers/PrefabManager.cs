using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;
#nullable disable
public class PrefabManager
{
    public static ZNetScene _scene;
    public static ObjectDB _db;
    public static GameObject _root;
    public static List<GameObject> prefabsToRegister;

    public static Transform root
    {
        get
        {
            if (_root == null)
            {
                _root = new GameObject("root");
                Object.DontDestroyOnLoad(_root);
                _root.SetActive(false);
            }

            return _root.transform;
        }
    }

    static PrefabManager()
    {
        prefabsToRegister = [];
        WhiteCastlePlugin.harmony.Patch(
            AccessTools.DeclaredMethod(typeof(FejdStartup), nameof(FejdStartup.Awake)),
            new HarmonyMethod(AccessTools.DeclaredMethod(typeof(PrefabManager), nameof(FejdStartup_Awake_Prefix))));
        WhiteCastlePlugin.harmony.Patch(AccessTools.DeclaredMethod(typeof(ZNetScene), nameof(ZNetScene.Awake)),
            prefix: new HarmonyMethod(AccessTools.DeclaredMethod(typeof(PrefabManager),
                nameof(ZNetScene_Awake_Prefix))));
    }

    public static void FejdStartup_Awake_Prefix(FejdStartup __instance)
    {
        _scene = __instance.m_objectDBPrefab.GetComponent<ZNetScene>();
        _db = __instance.m_objectDBPrefab.GetComponent<ObjectDB>();
        
        Assets.SetupWhiteMarblePieces();
        Assets.SetupVfx();
        Assets.LoadBrazierAssets();

        BuildPiece.Patch_FejdStartup(__instance);
    }

    public static bool TryGetPrefab(string id, out GameObject prefab)
    {
        if (ZNetScene.instance) prefab = ZNetScene.instance.GetPrefab(id);
        else if (_scene != null) prefab = _scene.m_prefabs.FirstOrDefault(p => p.name == id);
        else prefab = null;
        return prefab != null;
    }

    public static void Register(GameObject prefab)
    {
        if (!prefabsToRegister.Contains(prefab)) prefabsToRegister.Add(prefab);
        if (!_scene.m_prefabs.Contains(prefab)) _scene.m_prefabs.Add(prefab);
    }

    public static void ZNetScene_Awake_Prefix(ZNetScene __instance)
    {
        foreach (var prefab in prefabsToRegister)
        {
            if (!__instance.m_prefabs.Contains(prefab))
            {
                __instance.m_prefabs.Add(prefab);
            }
        }
    }
}