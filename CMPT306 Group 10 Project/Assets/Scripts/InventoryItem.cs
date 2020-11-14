using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]

public class InventoryItem : ScriptableObject
{
    public Transform player;
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use()
    {
        
        thisEvent.Invoke();
    }

    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

    public void SpawnCandle(GameObject candle)
    {
        Instantiate(candle, player.position, player.rotation);
    }


    public void ExtendVision(Delay delayScript)
    {
        delayScript.Start();
        
    }
}

