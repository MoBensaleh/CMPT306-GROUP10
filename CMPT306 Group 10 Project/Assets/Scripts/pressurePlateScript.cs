using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateScript : MonoBehaviour
{
    bool boxDetected = false;
    [SerializeField] KeyDoor door;

    private void OnTriggerEnter2D(Collider2D collider) {
        Box box = collider.GetComponent<Box>();

        if (box != null){
            boxDetected = true;
        } else {
            boxDetected = false;
        }
    }

    void Update(){
        if (boxDetected){
            door.OpenDoor();
        } else{
            door.CloseDoor();
        }
    }
}
