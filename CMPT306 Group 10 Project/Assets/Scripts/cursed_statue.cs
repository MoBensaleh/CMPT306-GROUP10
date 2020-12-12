using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursed_statue : MonoBehaviour
{
    bool activated = false;
    [SerializeField] public Sprite statue_sprite_on;
    private void OnCollisionEnter2D(Collision2D collider) {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy != null && activated == false){
            KeyHolder.amountOfStatuesActivated = KeyHolder.amountOfStatuesActivated + 1;
            Debug.Log(KeyHolder.amountOfStatuesActivated);
            this.GetComponent<SpriteRenderer>().sprite = statue_sprite_on;
            activated = true;
        } 
    }
}
