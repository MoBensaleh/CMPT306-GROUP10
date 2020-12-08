﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

    public void QuitToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void GoToBonusLevel() {
        SceneManager.LoadScene("Bonus Level");
    }
}
