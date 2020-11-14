using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]

public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;
    private Delay delay;


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

    public void StunEnemy(int seconds) {
        Debug.Log("stun");
        GameObject enemy = GameObject.Find("Enemy");
        enemy.GetComponent<Enemy>().StunEnemy(seconds);
    }

    public void SpawnCandle(GameObject candle)
    {
        Instantiate(candle, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
    }

    public void Awakening(FieldOfView fov)
    {
        delay.Invoke("ExtendVision", 0f);
        delay.Invoke("NormalVision", 5f);

    }


}


