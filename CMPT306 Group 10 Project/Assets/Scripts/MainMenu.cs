﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Game");
   }

   public void QuitGame() {
       //Doesn't Work in unity editor
       Application.Quit();
       Debug.Log("QUIT");
   }
}
