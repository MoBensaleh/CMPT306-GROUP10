using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class FootStepScript : MonoBehaviour {
	public float stepRate = 0.4f;
	public float stepCoolDown;
	public AudioClip footStep;
	AudioSource footStepaudio;
	public AudioMixerGroup mixer;


	private void Start() {
		footStepaudio = gameObject.AddComponent<AudioSource>();
		footStepaudio.outputAudioMixerGroup = mixer;
		footStepaudio.clip = footStep;
	}

	// Update is called once per frame
	void Update() {
		if (Time.timeScale == 1f) {
			// If moving, play audio
			stepCoolDown -= Time.deltaTime;
			if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f) {
				footStepaudio.pitch = 1f + Random.Range(-0.2f, 0.2f);
				footStepaudio.PlayOneShot(footStep, 0.9f);
				stepCoolDown = stepRate;
			}
		}
	}
}