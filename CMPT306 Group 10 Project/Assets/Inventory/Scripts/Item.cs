using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public enum ItemType
    {
        //This is a list of all available items for the inventory system
        Apple,
        Fish_Cooked,
        Sword_Silver,
        Ore_Ruby,
        KeyBlue,
        KeyGreen,
        KeyRed,
        KeyYellow
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Apple:        return ItemAssets.Instance.apple;
            case ItemType.Fish_Cooked:  return ItemAssets.Instance.fish_cooked;
            case ItemType.Ore_Ruby:     return ItemAssets.Instance.ore_ruby;
            case ItemType.Sword_Silver: return ItemAssets.Instance.sword_silver;
            case ItemType.KeyBlue:      return ItemAssets.Instance.keyBlue;
            case ItemType.KeyGreen:     return ItemAssets.Instance.keyGreen;
            case ItemType.KeyRed:       return ItemAssets.Instance.keyRed;
            case ItemType.KeyYellow:    return ItemAssets.Instance.keyYellow;

        }
    }

}
