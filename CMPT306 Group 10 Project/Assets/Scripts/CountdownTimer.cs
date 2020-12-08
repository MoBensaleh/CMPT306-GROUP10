using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    SceneTransition transition;

    [SerializeField] public string levelToLoad;
    [SerializeField] public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        LoadLevelAfterTimer(levelToLoad);
    }

    private void LoadLevelAfterTimer(string nextLevelName) {
        if (timer <= 0) {
            Debug.Log("Load: " + nextLevelName);
            transition = this.GetComponent<SceneTransition>();
            transition.LoadLevel(nextLevelName);
        }
    }
}
