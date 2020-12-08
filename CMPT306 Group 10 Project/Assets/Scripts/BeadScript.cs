using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeadScript : MonoBehaviour
{
    public TimeCounter timer;

    private void Start()
    {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == ("Menu"))
        {
            PlayerPrefs.DeleteAll();
        }
        if (!PlayerPrefs.HasKey("BeadTotal"))
        {
            PlayerBeadPouch.beadTotal = 0;
            PlayerPrefs.SetInt("BeadTotal", PlayerBeadPouch.beadTotal);
        }


    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == ("Gameover"))
        {
            PlayerBeadPouch.beadTotal = 0;
            PlayerPrefs.DeleteKey("prevLevelTime");
            PlayerPrefs.DeleteKey("BeadTotal");
            /*            timer.minutes = 0;
                        timer.seconds = 0;*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBeadPouch.beadTotal += 1;
        BeadUIScript.beadTotal = PlayerBeadPouch.beadTotal;
        PlayerPrefs.SetInt("BeadTotal", PlayerBeadPouch.beadTotal);
        PlayerPrefs.Save();
        Destroy(gameObject);
    }

}
