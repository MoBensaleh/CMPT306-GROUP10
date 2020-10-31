using UnityEngine;
using System.Collections;

public class FootStepScript : MonoBehaviour {
	public float stepRate = 0.4f;
	public float stepCoolDown;
	public AudioClip footStep;
	AudioSource footStepaudio;


	private void Start() {
		footStepaudio = gameObject.AddComponent<AudioSource>();
		footStepaudio.clip = footStep;
	}

	// Update is called once per frame
	void Update() {
		// If moving, play audio
		stepCoolDown -= Time.deltaTime;
		if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f) {
			footStepaudio.pitch = 1f + Random.Range(-0.2f, 0.2f);
			footStepaudio.PlayOneShot(footStep, 0.9f);
			stepCoolDown = stepRate;
		}
	}
}