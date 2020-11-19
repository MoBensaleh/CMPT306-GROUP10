using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{


    public GameObject inventoryPanel;
    public bool inventoryActive;

    private void Start()
    {

        inventoryPanel.SetActive(false);
        inventoryActive = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            if (inventoryActive)
            {

                inventoryPanel.SetActive(false);
                inventoryActive = false;
            }
            else
            {
                inventoryPanel.SetActive(true);
                inventoryActive = true;

            }


        }
    }
}