using System.IO;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using PieceManager;
using WhiteCastle;

namespace WhiteCastle;

public static class ReadMeBuilder
{
    public static bool buildReadme = false;
    private static bool exportSprites = false;

    static ReadMeBuilder()
    {
        WhiteCastlePlugin.instance._harmony.Patch(
            AccessTools.DeclaredMethod(typeof(Player), nameof(Player.OnSpawned)),
            postfix: new HarmonyMethod(AccessTools.DeclaredMethod(typeof(ReadMeBuilder), nameof(Build))));
    }

    public static void Init(bool exportIcons = true)
    {
        buildReadme = true;
        exportSprites = exportIcons;
    }

    public static void ExportLocalization()
    {
        var path = Path.Combine(Paths.ConfigPath, WhiteCastlePlugin.ModName);
        Directory.CreateDirectory(path);
        StringBuilder sb = new StringBuilder();
        
        foreach (var build in BuildPiece.registeredPieces)
        {
            var name = build.Prefab.GetComponent<Piece>().m_name;
            var localized = Localization.instance.Localize(name);
            sb.AppendLine(name.Replace("$", string.Empty) + ": " + localized);    
        }
        
        File.WriteAllText(Path.Combine(path, "English.yml"), sb.ToString());
    }
    
    public static void Build()
    {
        ExportLocalization();
        BuildAlt();
    }
    public static void BuildAlt()
    {
        if (!buildReadme) return;

        var path = Path.Combine(Paths.ConfigPath, WhiteCastlePlugin.ModName);
        Directory.CreateDirectory(path);

        var sb = new StringBuilder();
        sb.AppendLine($"# {WhiteCastlePlugin.ModName}");
        sb.AppendLine();
        sb.AppendLine("| Icon | Internal ID | Name | Description | Resources |");
        sb.AppendLine("|:---:|:---|:---|:---|:---|");

        foreach (var build in BuildPiece.registeredPieces)
        {
            var component = build.Prefab.GetComponent<Piece>();
            var internalId = component.name;
            var unLocalizedName = component.m_name;
            var unLocalizedDescription = component.m_description;
            var iconUrl = $"https://raw.githubusercontent.com/RustyMods/{WhiteCastlePlugin.ModName}/refs/heads/master/icons/" + component.name + ".png";
            var resources = string.Join(", ", build.RequiredItems.Requirements.Select(r => $"{r.itemName} x {r.amount}"));

            if (exportSprites)
            {
                IconExport.ExportSprite(component.m_icon, path, component.name);
            }

            sb.AppendLine($"| ![{internalId}]({iconUrl}) | `{internalId}` | {Clean(unLocalizedName)} | {Clean(unLocalizedDescription)} | {Clean(resources)} |");
        }

        File.WriteAllText(Path.Combine(path, "README.md"), sb.ToString());
    }

    // Pipes and line breaks would break a table row
    private static string Clean(string text) => string.IsNullOrEmpty(text) ? "" : text.Replace("|", "\\|").Replace("\r", "").Replace("\n", " ");
}