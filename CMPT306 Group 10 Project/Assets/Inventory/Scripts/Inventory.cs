using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Apple, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Fish_Cooked, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Sword_Silver, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Ore_Ruby, amount = 1 });

        Debug.Log(itemList.Count);

    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
