using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public Transform followTarget;	// assign in editor to character
	private Vector3 targetPos;
	public float moveSpeed = 10f;	// default value

	public float maxZoom = 2f; // default value
	public float minZoom = 8f; // default value

	void Start()
	{
		startingPosition = transform.position;
	}

	void Update () 
	{
		// If there is a character assigned to follow, then follow
		if(followTarget != null)
		{
			adjustZoom();
			targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
			checkForQuit();
		}
	}

	// Moves the camera closer or further from the character based on scroll wheel, up to a set value
	void adjustZoom() {
		//Zoom when mouse wheel used
		if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + 1, maxZoom, minZoom);
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - 1, maxZoom, minZoom);
		}
	}

	// Quits the application when "ESC" is pressed
	void checkForQuit() {
		if (Input.GetKeyDown(KeyCode.Escape) == true) {
			Application.Quit();
		}
	}
}

// public class Camera : MonoBehaviour
// {
//     public Transform player;

//     // Update is called once per frame
//     void Update()
//     {
//         transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
//     }



// }
