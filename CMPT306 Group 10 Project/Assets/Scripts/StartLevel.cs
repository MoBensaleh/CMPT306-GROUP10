using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject startMenuUI;
    
    void Start()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BeginLevel(){
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
