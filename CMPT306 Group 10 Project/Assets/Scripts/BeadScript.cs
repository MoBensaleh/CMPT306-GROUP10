using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeadScript : MonoBehaviour
{
    public TimeCounter timer;
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == ("Gameover"))
        {
            PlayerBeadPouch.beadTotal = 0;
            timer.minutes = 0;
            timer.seconds = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBeadPouch.beadTotal += 1;
        BeadUIScript.beadTotal = PlayerBeadPouch.beadTotal;
        Destroy(gameObject);
    }

}
