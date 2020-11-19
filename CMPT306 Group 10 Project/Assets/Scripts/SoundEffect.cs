using UnityEngine;

public class SoundEffect : MonoBehaviour {

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic() {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic() {
        audioSource.Stop();
    }

    public void PauseMusic() {
        audioSource.Pause();
    }


}