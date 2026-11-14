using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace WhiteCastle;

public static partial class Assets
{
    private static List<string> materials = 
    [
        "Details",
        "Heaven_Castle_1_2",
        "Heaven_Castle_1_4",
        "Heaven_Castle_2_1",
        "Heaven_Castle_2_1_el",
        "Heaven_Castle_2_2",
        "Heaven_Castle_2_3",
        "Heaven_Castle_3_1",
        "Heaven_Castle_3_2"
    ];
    
    private static void SetupMaterials()
    {
        var bundle = PiecePrefabManager.RegisterAssetBundle("white_castle_bundle");

        foreach (var mat in materials)
        {
            var data = new MaterialData(bundle.LoadAsset<Material>(mat), MaterialReplacer.ShaderType.PieceShader);
            data.floatProps["_Metallic"] = 0.5f;
            data.floatProps["_Glossiness"] =0.8f;
            data.vectorProps["_EmissionColor"] = Vector4.zero;
            // details.vectorProps["_Color"] = new Vector4(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}