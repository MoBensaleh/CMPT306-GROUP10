using UnityEngine;

public class WinConditionsMet : MonoBehaviour {
    SceneTransition transition;
    SoundEffect winSound;


    void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            Debug.Log("Victory");
            Time.timeScale = 0f;

            winSound = this.GetComponentInChildren<SoundEffect>();
            transition = this.GetComponent<SceneTransition>();

            transform.DetachChildren();

            winSound.PlayMusic();
            transition.LoadLevel("Win");
        }
    }

}
