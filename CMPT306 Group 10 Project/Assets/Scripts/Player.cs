using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    float xMovement, yMovement;
    public GridMap areas;
    Vector3 newLocation;

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");
        newLocation = transform.position + new Vector3(xMovement, yMovement, 0) * speed * Time.deltaTime;
        if (areas.RetrieveState(newLocation).unblocked) transform.position = newLocation;
    }
}
