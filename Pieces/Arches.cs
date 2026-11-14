using System.Collections.Generic;
using PieceManager;

namespace WhiteCastle;

public static partial class Assets
{
    private static Dictionary<string, string> arches = new()
    {
        ["piece_white_marble_arch_1"] = "Steep White Marble Arch",
        ["piece_white_marble_arch_2"] = "Wide White Marble Arch",
        ["piece_white_marble_arch_3"] = "White Marble Arch Section",
        ["piece_white_marble_base"] = "White Marble Arch Base",
        ["piece_white_marble_arch_1_inverted"] = "White Marble Arch",
        ["piece_white_marble_arch_2_inverted"] = "White Marble Arch",
        ["piece_white_marble_base_inverted"] = "White Marble Arch Base"
    };
    
    private static void SetupArches()
    {
        foreach (var kvp in arches)
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
}