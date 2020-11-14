using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform throwOrigin;
    public GameObject crossPrefab;
    public InventoryItem item;
    private InventoryPanel inventoryPanel;

    public float throwForce = 20f;


    // Update is called once per frame
    void Update()
    {
        while (!inventoryPanel.inventoryActive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ThrowItem();
                item.numberHeld -= 1;
                if (item.numberHeld < 0)
                {
                    item.numberHeld = 0;
                }

            }
        
        }
    }

    void ThrowItem()
    {
        if (item.numberHeld > 0)
        {
            GameObject cross = Instantiate(crossPrefab, throwOrigin.position, throwOrigin.rotation);
            Rigidbody2D rb = cross.GetComponent<Rigidbody2D>();
            rb.AddForce(throwOrigin.up * throwForce, ForceMode2D.Impulse);

        }
        
    }
}
