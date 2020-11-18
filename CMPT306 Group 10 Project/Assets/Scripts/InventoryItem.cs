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
        
        GameObject grid = GameObject.Find("Grid");
        int maxenemies = grid.GetComponent<DungeonGenerator>().getMaxEnemies();
        for (int i = 1; i < maxenemies + 1; i++) {
            enemy = GameObject.Find("Enemy(" + i.ToString() + ")");
            // enemy = GameObject.Find("Enemy(Clone)");
            enemy.GetComponent<Enemy>().StunEnemy(seconds);
        }
    }
    

    public void SpawnCandle(GameObject candle)
    {
        Instantiate(candle, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
    }


    
   
    
    
    public void Awakening()
    {
        GameObject delayGameObject = GameObject.Find("FOV");
        Delay delay = delayGameObject.GetComponent<Delay>();
        delay.StartAwakening();
    }

            









}


