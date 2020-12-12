using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject otherInventoryPanel;
    
    void Start()
    {
        otherInventoryPanel.SetActive(false);
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BeginLevel(){
        startMenuUI.SetActive(false);
        otherInventoryPanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
