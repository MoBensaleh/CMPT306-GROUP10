using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    SceneTransition transition;
    SoundEffect winSound;

    public void goToLevel2() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Game Level 2");
   }

   public void goToLevel3() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Game Level 3");
   }

   public void win() {
        Debug.Log("Victory");
        Time.timeScale = 0f;

        winSound = this.GetComponentInChildren<SoundEffect>();
        transition = this.GetComponent<SceneTransition>();

        winSound.PlayMusic();
        transition.LoadLevel("Win");
    }
}
