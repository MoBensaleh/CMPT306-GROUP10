using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateScript : MonoBehaviour
{
    [SerializeField] KeyDoor door;

    private void OnTriggerEnter2D(Collider2D collider) {
        Box box = collider.GetComponent<Box>();

        if (box != null){
            KeyHolder.amountOfPressurePlatesActivated = KeyHolder.amountOfPressurePlatesActivated + 1;
        } else {
            KeyHolder.amountOfPressurePlatesActivated = KeyHolder.amountOfPressurePlatesActivated - 1;
        }
    }
}
