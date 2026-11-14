using PieceManager;

namespace WhiteCastle;

public static partial class Assets
{
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