using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inventoryPanel;
    public bool usingPausePanel;

    private void Start()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        inventoryPanel.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        usingPausePanel = true;
    }

    public void QuitGame() {
        Debug.Log("hi");
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pauseMenuUI.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            pauseMenuUI.SetActive(false);
        }

    }
}
