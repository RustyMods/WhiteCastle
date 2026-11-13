using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static readonly Texture2D white_marble_texture = PiecePrefabManager
        .RegisterAssetBundle("white_castle_bundle").LoadAsset<Texture2D>("white_marble_d");
    

    private static Dictionary<string, (string, string)> marbles = new()
    {
        ["blackmarble_1x1"] = ("piece_white_marble_1x1", "White Marble 1x1x1"),
        ["blackmarble_2x1x1"] = ("piece_white_marble_2x1x1", "White Marble 2x1x1"),
        ["blackmarble_2x2_enforced"] = ("piece_white_marble_2x2_enforced", "White Marble 2x2x2 Enforced"),
        ["blackmarble_2x2x1"] = ("piece_white_marble_2x2x1", "White Marble 2x2x1"),
        ["blackmarble_2x2x2"] = ("piece_white_marble_2x2x2", "White Marble 2x2x2"),
        ["blackmarble_arch"] = ("piece_white_marble_arch_1", "White Marble Arch"),
        ["blackmarble_base_1"] = ("piece_white_marble_base_1", "White Marble Plinth"),
        ["blackmarble_base_2"] = ("piece_white_marble_base_2", "White Marble Plinth Wide"),
        ["blackmarble_basecorner"] = ("piece_white_marble_base_corner", "White Marble Plinth Corner"),
        ["blackmarble_column_1"] = ("piece_white_marble_column_1", "White Marble Column Small"),
        ["blackmarble_column_2"] = ("piece_white_marble_column_2", "White Marble Column Wide"),
        ["blackmarble_column_3"] = ("piece_white_marble_column_3", "White Marble Column Tall"),
        ["blackmarble_floor"] = ("piece_white_marble_floor", "White Marble Floor"),
        ["blackmarble_floor_triangle"] = ("piece_white_marble_floor_triangle", "White Marble Floor Triangle"),
        ["blackmarble_out_1"] = ("piece_white_marble_out_1", "White Marble Cornice"),
        ["blackmarble_out_2"] = ("piece_white_marble_out_2", "White Marble Cornice Wide"),
        ["blackmarble_outcorner"] = ("piece_white_marble_outcorner", "White Marble Cornice Corner"),
        ["blackmarble_slope_1x2"] = ("piece_white_marble_slope_1x2", "White Marble Slope 1x2"),
        ["blackmarble_slope_inverted_1x2"] = ("piece_white_marble_slope_inverted_1x2", "White Marble Slope Inverted 1x2"),
        ["blackmarble_stair"] = ("piece_white_marble_stair", "White Marble Stair"),
        ["blackmarble_tile_floor_1x1"] = ("piece_white_marble_tile_floor_1x1", "White Marble Tile Floor 1x1"),
        ["blackmarble_tile_floor_2x2"] = ("piece_white_marble_tile_floor_2x2", "White Marble Tile Floor 2x2"),
        ["blackmarble_tile_wall_1x1"] = ("piece_white_marble_tile_wall_1x1", "White Marble Tile Wall 1x1"),
        ["blackmarble_tile_wall_2x2"] = ("piece_white_marble_tile_wall_2x2", "White Marble Tile Wall 2x2"),
        ["blackmarble_tile_wall_2x4"] = ("piece_white_marble_tile_wall_2x4", "White Marble Tile Wall 2x4"),
        ["blackmarble_tip"] = ("piece_white_marble_tip", "White Marble Quarter Spire")
    };
    private static bool loaded_white_marble;

    public static void SetupWhiteMarblePieces()
    {
        if (loaded_white_marble) return;

        Material white_marble = null;
        Material white_marble_worn = null;
        Material white_marble_movable = null;


        foreach (var kvp in marbles)
            if (PrefabManager.TryGetPrefab(kvp.Key, out var source))
            {
                (string id, string name) = kvp.Value;
                
                var prefab = Object.Instantiate(source, PrefabManager.root);
                prefab.name =id;

                var meshRenderers = prefab.GetComponentsInChildren<MeshRenderer>(true);
                foreach (var r in meshRenderers)
                {
                    var material = r.sharedMaterial;
                    switch (material.name)
                    {
                        case "blackmarble":
                            if (white_marble == null)
                            {
                                white_marble = new Material(material);
                                white_marble.name = "whitemarble";
                                white_marble.mainTexture = white_marble_texture;
                            }

                            r.sharedMaterial = white_marble;
                            break;
                        case "blackmarble_worn":
                            if (white_marble_worn == null)
                            {
                                white_marble_worn = new Material(material);
                                white_marble_worn.name = "whitemarble_worn";
                                white_marble_worn.mainTexture = white_marble_texture;
                            }

                            r.sharedMaterial = white_marble_worn;
                            break;
                        case "blackmarble_movable":
                            if (white_marble_movable == null)
                            {
                                white_marble_movable = new Material(material);
                                white_marble_movable.name = "whitemarble_movable";
                                white_marble_movable.mainTexture = white_marble_texture;
                            }

                            r.sharedMaterial = white_marble_movable;
                            break;
                        default:
                            continue;
                    }
                }

                var piece = prefab.GetComponent<Piece>();
                var wnt = prefab.GetComponent<WearNTear>();

                wnt.m_destroyedEffect = new EffectListRef("vfx_WhiteMarbleDestroyed", "sfx_rock_destroyed");
                wnt.m_hitEffect = new EffectListRef("vfx_WhiteMarbleHit", "sfx_rock_hit");

                piece.m_name = "";
                piece.m_description = "";

                PrefabManager.Register(prefab);

                var build = new BuildPiece(prefab);
                build.Name.English(name);
                build.Description.English("");
                build.Category.Set("White Castle");
                build.RequiredItems.Add("Ice", 1, true);
                build.Snapshot();
            }

        loaded_white_marble = true;
    }
}