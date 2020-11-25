using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inventoryPanel;
    public bool usingPausePanel;
    public GameObject otherInventoryPanel;

    private void Start()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
        otherInventoryPanel.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
                otherInventoryPanel.SetActive(true);
            } else {
                Pause();
                otherInventoryPanel.SetActive(false);
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

    public void QuitToMenu() {
        inventoryPanel.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
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
