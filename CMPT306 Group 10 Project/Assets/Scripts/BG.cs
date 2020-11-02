using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] private Transform camPos;

    // Update is called once per frame
    void Update()
    {
        //Follows Camera
        transform.position = new Vector3(camPos.position.x, camPos.position.y, transform.position.z);
    }
}
