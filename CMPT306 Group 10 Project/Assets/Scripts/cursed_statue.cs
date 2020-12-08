using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursed_statue : MonoBehaviour
{
    [SerializeField] public Sprite statue_sprite_on;
    private void OnCollisionEnter2D(Collision2D collider) {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy != null){
            KeyHolder.amountOfStatuesActivated = KeyHolder.amountOfStatuesActivated + 1;
            Debug.Log(KeyHolder.amountOfStatuesActivated);
            this.GetComponent<SpriteRenderer>().sprite = statue_sprite_on;
        } 
    }
}
