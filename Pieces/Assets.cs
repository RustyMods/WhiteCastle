using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static Dictionary<string, string> arches = new()
    {
        ["piece_white_marble_arch"] = "White Marble Arch",
        ["piece_white_marble_arch_2"] = "White Marble Arch",
        ["piece_white_marble_arch_3"] = "White Marble Arch",
        ["piece_white_marble_base"] = "White Marble Arch Base"
    };

    private static Dictionary<string, string> beams = new()
    {
        ["piece_white_marble_beam_1"] =  "White Marble Beam 1",
        ["piece_white_marble_beam_2"] = "White Marble Beam 2",
        ["piece_white_marble_beam_3"] = "White Marble Beam 3",
        ["piece_white_marble_beam_4"] = "White Marble Beam 4",
    };

    private static Dictionary<string, string> misc = new()
    {
        ["piece_white_marble_bell"] = "Bell",
        // ["piece_white_marble_brazier"] = "Brazier",
        ["piece_white_marble_detail_1"] = "Gold Pole"
    };

    private static Dictionary<string, string> columns = new()
    {
        ["piece_white_marble_column_1_1"] = "Column Base",
        ["piece_white_marble_column_1_2"] = "Column Section",
        ["piece_white_marble_column_1_3"] = "Column Section",
        ["piece_white_marble_column_1_4"] = "Column Top",
        ["piece_white_marble_column_2_1"] = "Column Base",
        ["piece_white_marble_column_2_2"] = "Column Section",
        ["piece_white_marble_column_2_3"] = "Column 2",
        ["piece_white_marble_column_3_1"] = "Column 2",
        ["piece_white_marble_column_3_2"] = "Column 2",
        ["piece_white_marble_column_4_1"] = "Column Base",
        ["piece_white_marble_column_4_2"] = "Column Step",
        ["piece_white_marble_column_4_3"] = "Column Section",
        ["piece_white_marble_column_4_4"] = "Column Top",
        ["piece_white_marble_column_4_5"] = "Column Base",
        ["piece_white_marble_column_5_1"] = "Column Section",
        ["piece_white_marble_column_5_2"] = "Column Base",
        ["piece_white_marble_column_6_1"] = "Column Section",
        ["piece_white_marble_column_6_2"] = "Column Top",
        ["piece_white_marble_column_6_3"] = "Column Base",
        ["piece_white_marble_column_7_1"] = "Column Section",
        ["piece_white_marble_column_7_2"] = "Column Top",
        ["piece_white_marble_column_7_3"] = "Column Top",
        ["piece_white_marble_column_7_4"] = "Column Base",
        ["piece_white_marble_column_8_1"] = "Column Section",
        ["piece_white_marble_column_8_2"] = "Column Section",
        ["piece_white_marble_column_8_3"] = "Column Top",
        ["piece_white_marble_column_8_4"] = "Column Base",
    };

    private static Dictionary<string, string> contre = new()
    {
        ["piece_white_marble_contreforce_1"] = "Counterfort",
        ["piece_white_marble_contreforce_2"] = "Counterfort",
        ["piece_white_marble_contreforce_2_1"] = "Counterfort",
        ["piece_white_marble_contreforce_2_2"] = "Counterfort",
        ["piece_white_marble_contreforce_3"] = "Counterfort",
        ["piece_white_marble_contreforce_3_1"] = "Counterfort Base",
        ["piece_white_marble_contreforce_3_2"] = "Counterfort Section",
        ["piece_white_marble_contreforce_3_3"] = "Counterfort Top",
        ["piece_white_marble_contreforce_4"] = "Counterfort",
        ["piece_white_marble_contreforce_5"] = "Counterfort",
    };

    private static Dictionary<string, string> cornices = new()
    {
        ["piece_white_marble_cornice_1"] = "Cornice",
        ["piece_white_marble_cornice_2"] = "Cornice",
        ["piece_white_marble_cornice_3"] = "Cornice"
    };

    private static Dictionary<string, string> deco = new()
    {
        ["piece_white_marble_deco_1"] = "Deco",
        ["piece_white_marble_deco_2"] = "Deco",
        ["piece_white_marble_deco_3"] = "Deco",
        ["piece_white_marble_deco_4"] = "Deco",
        ["piece_white_marble_deco_5"] = "Deco",
        ["piece_white_marble_deco_6"] = "Deco",
        ["piece_white_marble_deco_7"] = "Deco",
        ["piece_white_marble_deco_8"] = "Deco",
        ["piece_white_marble_deco_9"] = "Deco",
        ["piece_white_marble_deco_10"] = "Deco"
    };

    private static Dictionary<string, string> flats = new()
    {
        ["piece_white_marble_flat_1"] = "Ornament",
        ["piece_white_marble_flat_2"] = "Ornament",
        ["piece_white_marble_flat_3"] = "Ornament",
        ["piece_white_marble_flat_4"] = "Ornament",
        ["piece_white_marble_flat_5"] = "Ornament",
    };

    private static Dictionary<string, string> pillars = new()
    {
        ["piece_white_marble_pillar_1"] = "Pillar",
        ["piece_white_marble_pillar_2"] = "Pillar",
        ["piece_white_marble_pillar_3"] = "Pillar",
    };

    private static Dictionary<string, string> walls = new()
    {
        ["piece_white_marble_wall_1"] = "Wall Detail",
        ["piece_white_marble_wall_2"] = "Wall Detail",
    };

    private static Dictionary<string, string> windows = new()
    {
        ["piece_white_marble_window_1_1"] = "Window Base",
        ["piece_white_marble_window_1_2"] = "Window Section",
        ["piece_white_marble_window_1_3"] = "Window Section",
        ["piece_white_marble_window_1_4"] = "Window Top",
        ["piece_white_marble_window_1_5"] = "Window Top",
        ["piece_white_marble_window_2_1"] = "Window Base",
        ["piece_white_marble_window_2_2"] = "Window Section",
        ["piece_white_marble_window_2_3"] = "Window Section",
        ["piece_white_marble_window_2_4"] = "Window Top",
        ["piece_white_marble_window_2_5"] = "Window Top",
        ["piece_white_marble_window_3_1"] = "Window Section",
        ["piece_white_marble_window_3_2"] = "Window Top",
        ["piece_white_marble_window_3_3"] = "Window Base",
    };
    public static void Setup()
    {
        SetupArches();
        SetupBeams();
        SetupMisc();
        SetupBrazier();
        SetupColumns();
        SetupCounterforts();
        SetupCorniches();
        SetupDeco();
        SetupFlats();
        SetupPillars();
        SetupWalls();
        SetupWindows();
        
        SetupMaterials();
    }

    private static void SetupArches()
    {
        foreach (var kvp in arches)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupBeams()
    {
        foreach (var kvp in beams)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupMisc()
    {
        foreach (var kvp in misc)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupColumns()
    {
        foreach (var kvp in columns)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupCounterforts()
    {
        foreach (var kvp in contre)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupCorniches()
    {
        foreach (var kvp in cornices)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupDeco()
    {
        foreach (var kvp in deco)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupFlats()
    {
        foreach (var kvp in flats)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupPillars()
    {
        foreach (var kvp in pillars)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupWalls()
    {
        foreach (var kvp in walls)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupWindows()
    {
        foreach (var kvp in windows)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Ice", 1, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    
    private static void SetupMaterials()
    {
        var bundle = PiecePrefabManager.RegisterAssetBundle("white_castle_bundle");
        
        var details = new MaterialData(
            bundle.LoadAsset<Material>("Details"),
            MaterialReplacer.ShaderType.PieceShader);
        details.floatProps["_Metallic"] = 0.5f;
        details.floatProps["_Glossiness"] =0.8f;
        details.vectorProps["_EmissionColor"] = Vector4.zero;
        // details.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat1 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_1_2"),
            MaterialReplacer.ShaderType.PieceShader);
        mat1.floatProps["_Metallic"] = 0.5f;
        mat1.floatProps["_Glossiness"] = 0.8f;
        mat1.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat1.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat2 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_1_4"),
            MaterialReplacer.ShaderType.PieceShader);
        mat2.floatProps["_Metallic"] = 0.5f;
        mat2.floatProps["_Glossiness"] =0.8f;
        mat2.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat2.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat3 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_2_1"),
            MaterialReplacer.ShaderType.PieceShader);
        mat3.floatProps["_Metallic"] = 0.5f;
        mat3.floatProps["_Glossiness"] = 0.8f;
        mat3.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat3.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat4 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_2_1_el"),
            MaterialReplacer.ShaderType.PieceShader);
        mat4.floatProps["_Metallic"] = 0.5f;
        mat4.floatProps["_Glossiness"] = 0.8f;
        mat4.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat4.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat5 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_2_2"),
            MaterialReplacer.ShaderType.PieceShader);
        mat5.floatProps["_Metallic"] = 0.5f;
        mat5.floatProps["_Glossiness"] = 0.8f;
        mat5.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat5.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat6 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_2_3"),
            MaterialReplacer.ShaderType.PieceShader);
        mat6.floatProps["_Metallic"] = 0.5f;
        mat6.floatProps["_Glossiness"] = 0.8f;
        mat6.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat6.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat7 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_3_1"),
            MaterialReplacer.ShaderType.PieceShader);
        mat7.floatProps["_Metallic"] = 0.5f;
        mat7.floatProps["_Glossiness"] = 0.8f;
        mat7.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat7.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        
        var mat8 = new MaterialData(
            bundle.LoadAsset<Material>("Heaven_Castle_3_2"),
            MaterialReplacer.ShaderType.PieceShader);
        mat8.floatProps["_Metallic"] = 0.5f;
        mat8.floatProps["_Glossiness"] = 0.8f;
        mat8.vectorProps["_EmissionColor"] = Vector4.zero;
        // mat8.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
    }
}