using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public Animator animator;
    public float transitionDelayTime = 1.0f;

    public static SceneTransition transition;

    public void LoadLevel(string level) {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
        Debug.Log("Load Game Over");
        StartCoroutine(DelayLoadLevel(level));
    }

    IEnumerator DelayLoadLevel(string level) {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSecondsRealtime(transitionDelayTime);
        SceneManager.LoadScene(level);
    }
}