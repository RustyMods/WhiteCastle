using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{


    private static Dictionary<string, string> beams = new()
    {
        ["piece_white_marble_beam_1"] =  "White Marble Beam 1",
        ["piece_white_marble_beam_2"] = "White Marble Beam 2",
        ["piece_white_marble_beam_3"] = "White Marble Beam 3",
        ["piece_white_marble_beam_4"] = "White Marble Beam 4",
    };

    private static Dictionary<string, string> poles = new()
    {
        ["piece_white_marble_detail_1"] = "Horizontal Gold Pole",
        ["piece_white_marble_detail_2"] = "Vertical Gold Pole"
    };

    private static Dictionary<string, string> columns = new()
    {
        ["piece_white_marble_column_1_2"] = "Small Column Section",
        ["piece_white_marble_column_3_1"] = "Column Flower",
        ["piece_white_marble_column_3_2"] = "Column Flower Stacked",
        ["piece_white_marble_column_3_3"] = "Column Flower Short",
        ["piece_white_marble_column_4_1"] = "Column Oval Base",
        ["piece_white_marble_column_4_2"] = "Column Step",
        ["piece_white_marble_column_4_3"] = "Column Cylinder Section",
        ["piece_white_marble_column_5_2"] = "Column Small Cube",
        ["piece_white_marble_column_7_1"] = "Column Slab Section",
        ["piece_white_marble_column_7_2"] = "Column Slab Section",
        ["piece_white_marble_column_7_3"] = "Column Slab Top",
        ["piece_white_marble_column_7_4"] = "Column Slab Base",
        ["piece_white_marble_column_8_2"] = "Medium Column Cylinder Section",

    };

    private static Dictionary<string, string> goldColumns = new()
    {
        ["piece_white_marble_column_1_1"] = "Small Gold Column Cap",
        ["piece_white_marble_column_1_3"] = "Small Gold Column Section",
        ["piece_white_marble_column_1_4"] = "Small Gold Column Top",
        ["piece_white_marble_column_2_1"] = "Column Base",
        ["piece_white_marble_column_2_2"] = "Column Braided Section",
        ["piece_white_marble_column_2_3"] = "Column Star",
        ["piece_white_marble_column_4_4"] = "Column Cylinder Cap",
        ["piece_white_marble_column_4_5"] = "Column Cylinder Base",
        ["piece_white_marble_column_5_1"] = "Column Stripped Section",
        ["piece_white_marble_column_6_1"] = "Column Line Section",
        ["piece_white_marble_column_6_2"] = "Column Line Cap",
        ["piece_white_marble_column_6_3"] = "Column Line Base",
        ["piece_white_marble_column_8_1"] = "Medium Column Section",
        ["piece_white_marble_column_8_3"] = "Medium Column Top",
        ["piece_white_marble_column_8_4"] = "Medium Column Base",
    };

    private static Dictionary<string, string> contre = new()
    {
        ["piece_white_marble_contreforce_1"] = "Wall Support",
        ["piece_white_marble_contreforce_2"] = "Wall Support",
        ["piece_white_marble_contreforce_2_1"] = "Slim Wall Support",
        ["piece_white_marble_contreforce_2_2"] = "Gold Detail",
        ["piece_white_marble_contreforce_3"] = "Wall Leaf",
        ["piece_white_marble_contreforce_3_1"] = "Counterfort Base",
        ["piece_white_marble_contreforce_3_2"] = "Counterfort Section",
        ["piece_white_marble_contreforce_3_3"] = "Counterfort Top",
        ["piece_white_marble_contreforce_4"] = "Counterfort Support",
        ["piece_white_marble_contreforce_5"] = "Double Wall Leaf",
    };

    private static Dictionary<string, string> cornices = new()
    {
        ["piece_white_marble_cornice_1"] = "Cornice",
        ["piece_white_marble_cornice_2"] = "Cornice Detail",
        ["piece_white_marble_cornice_3"] = "Cornice Leaf"
    };

    private static Dictionary<string, string> deco = new()
    {
        ["piece_white_marble_deco_1"] = "Wing Deco",
        ["piece_white_marble_deco_2"] = "Horn Deco",
        ["piece_white_marble_deco_3"] = "Carved Deco",
        ["piece_white_marble_deco_4"] = "Wall Deco",
        ["piece_white_marble_deco_5"] = "Deco Base",
        ["piece_white_marble_deco_6"] = "Ornament Deco",
        ["piece_white_marble_deco_7"] = "Ornament Deco",
        ["piece_white_marble_deco_8"] = "Ornament",
        ["piece_white_marble_deco_9"] = "Ceiling Deco",
        ["piece_white_marble_deco_10"] = "Gold Deco"
    };

    private static Dictionary<string, string> flats = new()
    {
        ["piece_white_marble_flat_1"] = "Wall Ornament",
        ["piece_white_marble_flat_2"] = "Wall Ornament",
        ["piece_white_marble_flat_3"] = "Wall Ornament",
        ["piece_white_marble_flat_4"] = "Half Ornament",
        ["piece_white_marble_flat_5"] = "Half Ornament",
    };

    private static Dictionary<string, string> pillars = new()
    {
        ["piece_white_marble_pillar_1"] = "Pillar",
        ["piece_white_marble_pillar_2"] = "Tapered Pillar",
        ["piece_white_marble_pillar_3"] = "Capped Pillar",
    };

    private static Dictionary<string, string> walls = new()
    {
        ["piece_white_marble_wall_1"] = "Wall Detail",
        ["piece_white_marble_wall_2"] = "Large Wall Detail",
    };

    private static Dictionary<string, string> windows = new()
    {
        ["piece_white_marble_window_1_1"] = "Square Window Base",
        ["piece_white_marble_window_1_2"] = "Square Window Section",
        ["piece_white_marble_window_1_3"] = "Square Window Detail",
        ["piece_white_marble_window_1_4"] = "Square Window Cap",
        ["piece_white_marble_window_1_5"] = "Square Window Top",
        ["piece_white_marble_window_3_1"] = "Rounded Window Section",
        ["piece_white_marble_window_3_2"] = "Rounded Window Top",
        ["piece_white_marble_window_3_3"] = "Rounded Window Base",
    };

    private static Dictionary<string, string> goldWindows = new()
    {
        ["piece_white_marble_window_2_1"] = "Gold Window Base",
        ["piece_white_marble_window_2_2"] = "Gold Window Section",
        ["piece_white_marble_window_2_3"] = "Gold Window Detail",
        ["piece_white_marble_window_2_4"] = "Gold Window Cap",
        ["piece_white_marble_window_2_5"] = "Gold Window Top",
    };
    public static void Setup()
    {
        SetupArches();
        SetupBeams();
        SetupPoles();
        SetupBell();
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
    
    private static void SetupBeams()
    {
        foreach (var kvp in beams)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("WhiteMarble_RS", 4, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }
    }
    
    private static void SetupPoles()
    {
        foreach (var kvp in poles)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Gold", 2, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();

            wnt.m_materialType = WearNTear.MaterialType.Iron;
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_metal");
            wnt.m_destroyedEffect = new EffectListRef( "sfx_metal_blocked");
            wnt.m_hitEffect = new EffectListRef("vfx_HitSparks");
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
            build.RequiredItems.Add("WhiteMarble_RS", 5, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            
            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }

        foreach (var kvp in goldColumns)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("WhiteMarble_RS", 5, true);
            build.RequiredItems.Add("Gold", 1, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 2, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 2, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 2, true);
            build.RequiredItems.Add("Gold", 1, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 2, true);
            build.RequiredItems.Add("Gold" , 1, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 5, true);
            build.RequiredItems.Add("Gold", 1, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 4, true);
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
            build.RequiredItems.Add("WhiteMarble_RS", 1, true);
            build.RequiredItems.Add("Gold", 2, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();

            piece.m_placeEffect = new EffectListRef("vfx_Place_stone_wall_2x1", "sfx_build_hammer_stone");
            wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
            wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");
        }

        foreach (var kvp in goldWindows)
        {
            var build = new BuildPiece("white_castle_bundle", kvp.Key);
            build.Name.English(kvp.Value);
            build.Description.English("");
            build.Category.Set("White Castle");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Gold", 2, true);
            build.Snapshot();

            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();

            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_metal");
            wnt.m_destroyedEffect = new EffectListRef( "sfx_metal_blocked");
            wnt.m_hitEffect = new EffectListRef("vfx_HitSparks");
        }
    }


}