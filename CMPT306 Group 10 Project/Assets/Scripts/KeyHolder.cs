using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHolder : MonoBehaviour
{
    SceneTransition transition;
    SoundEffect winSound;
    public static int keyList;
    public static int amountOfPressurePlatesActivated;
    public static int amountOfStatuesActivated;
    [SerializeField] int amountOfStatues;
    [SerializeField] int amountOfPressurePlates;
    [SerializeField] int amountOfKeys;

    private void Awake() {
        keyList = 0;
    }

    public bool ContainsAllKeys(){
        if (keyList >= amountOfKeys) {
            Debug.Log("All Keys contained");
            return true;
        } else {
            Debug.Log("Missing keys");
            return false;
        }
    }

    public bool allPressurePlatesActive(){
        if (amountOfPressurePlates <= amountOfPressurePlatesActivated){
            return true;
        } else {
            Debug.Log("Missing pressure plates");
            return false;
        }
    }

    public bool allStatuesActivated(){
        if (amountOfStatues <= amountOfStatuesActivated){
            return true;
        } else {
            Debug.Log("Missing statues");
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Key") {
            keyList = keyList + 1;
            Debug.Log(keyList);
        }

        if (collider.gameObject.tag == "Door"){
            if (ContainsAllKeys() && allPressurePlatesActive() && allStatuesActivated()){
                //Opens Door if all keys are obtained
                Destroy(collider.gameObject);
            }
        }

        Debug.Log("collison hit");
        if (collider.gameObject.tag == "Portal"){
            Debug.Log("portal hit");
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Game"){
                Time.timeScale = 1f;
                SceneManager.LoadScene("Game Level 2");
            } else if (sceneName == "Game Level 2"){
                Time.timeScale = 1f;
                SceneManager.LoadScene("Game Level 3");
            } else if (sceneName == "Game Level 3"){
                Debug.Log("Victory");
                Time.timeScale = 0f;

                winSound = collider.gameObject.GetComponentInChildren<SoundEffect>();
                transition = collider.gameObject.GetComponent<SceneTransition>();

                winSound.PlayMusic();
                transition.LoadLevel("Win");
            }
        }
    }
}
