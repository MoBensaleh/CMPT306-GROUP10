using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpotted : MonoBehaviour {
    private List<GameObject> enemies = new List<GameObject>();

    void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger!");
        if (other.tag == "Enemy")
            enemies.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Enemy")
            enemies.Remove(other.gameObject);
    }

    void Update() {
        RaycastHit hitInfo;
        foreach (GameObject enemy in enemies) {
            Ray ray = new Ray(transform.position, transform.position - enemy.transform.position);
            if (Physics.Raycast(ray, out hitInfo)) {
                enemy.SendMessage("OnVisible", SendMessageOptions.DontRequireReceiver);
                Debug.Log("Seen!");
                enemies.Remove(enemy.gameObject);
            }
        }
    }
}