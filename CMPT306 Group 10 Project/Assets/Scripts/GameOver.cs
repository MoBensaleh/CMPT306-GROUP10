using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        //Doesn't Work in unity editor
        Application.Quit();
        Debug.Log("QUIT");
    }
}
