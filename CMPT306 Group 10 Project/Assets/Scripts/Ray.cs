using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance);
        if(ray.collider != null)
        {
            Debug.DrawLine(transform.position, ray.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, ray.point);
        }
    }
}
