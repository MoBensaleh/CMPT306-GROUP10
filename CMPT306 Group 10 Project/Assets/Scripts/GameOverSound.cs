using UnityEngine;

public class GameOverSound : MonoBehaviour {

    private AudioSource gameOverAudioSource;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        gameOverAudioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic() {
        if (gameOverAudioSource.isPlaying) return;
        gameOverAudioSource.Play();
    }

    public void StopMusic() {
        gameOverAudioSource.Stop();
    }

    public void PauseMusic() {
        gameOverAudioSource.Pause();
    }


}