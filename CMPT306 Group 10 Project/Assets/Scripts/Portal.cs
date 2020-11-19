using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public void goToLevel2() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Game Level 2");
   }

   public void goToLevel3() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Game Level 3");
   }

   public void win() {
       Time.timeScale = 1f;
       SceneManager.LoadScene("Win");
   }
}
