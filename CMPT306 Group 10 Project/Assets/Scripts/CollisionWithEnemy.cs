using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionWithEnemy : MonoBehaviour {

    SceneTransition transition;
    GameOverSound sound;

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.tag == "Enemy") {
    //         Debug.Log("Enemy hit");
    //         Time.timeScale = 0f;

    //         sound = this.GetComponentInChildren<GameOverSound>();
    //         transition = this.GetComponent<SceneTransition>();

    //         transform.DetachChildren();

    //         sound.PlayMusic();
    //         transition.LoadLevel("Gameover");
    //     }
    // }


}
