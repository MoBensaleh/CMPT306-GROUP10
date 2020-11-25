using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Throw : MonoBehaviour
{
    public Transform throwOrigin;
    public GameObject crossPrefab;
    public InventoryItem item;
    public GameObject inventoryPanel;
    public GameObject PauseMenuPanel;
    public GameObject OptionsMenuPanel;
    public GameObject otherInventoryPanel;


    public float throwForce = 20f;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !IsMouseOverUI())
            {
            if (!inventoryPanel.activeSelf && !PauseMenuPanel.activeSelf && !OptionsMenuPanel.activeSelf)
            {
                ThrowItem();
                item.numberHeld -= 1;
                otherInventoryPanel.SetActive(false);
                otherInventoryPanel.SetActive(true);


            }



            if (item.numberHeld < 0)
            {
                item.numberHeld = 0;
            }

            
        
        }
    }
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
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
