using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static bool vfx_loaded;
    public static void SetupVfx()
    {
        if (vfx_loaded) return;
        PrefabManager.TryGetPrefab("vfx_MarbleDestroyed", out var vfx_MarbleDestroyed);
        PrefabManager.TryGetPrefab("vfx_MarbleHit", out var vfx_MarbleHit);
        
        ZNetView.m_forceDisableInit = true;
        var vfx_destroyed = UnityEngine.Object.Instantiate(vfx_MarbleDestroyed, PrefabManager.root);
        vfx_destroyed.name = "vfx_WhiteMarbleDestroyed";
        var des_renderer = vfx_destroyed.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        var black_marble_item =des_renderer.sharedMaterial;
        var white_marble_item = new Material(black_marble_item);
        white_marble_item.name = "white_marble_item";
        white_marble_item.mainTexture = white_marble_texture;
        des_renderer.sharedMaterial = white_marble_item;
        
        PrefabManager.Register(vfx_destroyed);
        
        var vfx_hit = UnityEngine.Object.Instantiate(vfx_MarbleHit, PrefabManager.root);
        vfx_hit.name = "vfx_WhiteMarbleHit";
        var hit_renderer = vfx_hit.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        hit_renderer.sharedMaterial = white_marble_item;
        
        PrefabManager.Register(vfx_hit);
        ZNetView.m_forceDisableInit = false;
        
        vfx_loaded = true;
    }
}