using ItemManager;
using UnityEngine;
using CraftingTable = ItemManager.CraftingTable;

namespace WhiteCastle;

public static partial class Assets
{
    private static bool item_loaded;

    public static void CreateWhiteMarble()
    {
        if (item_loaded) return;

        if (PrefabManager.TryGetPrefab("BlackMarble", out var BlackMarble))
        {
            var prefab = UnityEngine.Object.Instantiate(BlackMarble, PrefabManager.root);
            prefab.name = "WhiteMarble_RS";
            var component = prefab.GetComponent<ItemDrop>();
            component.m_itemData.m_shared.m_name = "item_white_marble";
            component.m_itemData.m_shared.m_description = "item_white_marble_desc";

            prefab.GetComponentInChildren<MeshRenderer>().sharedMaterials = [white_marble_item];
            
            
            var item = new Item(prefab);
            item.Name.English("White Marble");
            item.Description.English("");
            item.Snapshot();
            item.RequiredItems.Add("BlackMarble", 5);
            item.RequiredItems.Add("AncientCoin", 1);
            item.Crafting.Add(CraftingTable.StoneCutter, 1);
            item.CraftAmount = 10;
        }
        
        item_loaded = true;
    }
}