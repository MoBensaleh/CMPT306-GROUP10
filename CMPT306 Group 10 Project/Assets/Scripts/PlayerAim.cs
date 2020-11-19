using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private FieldOfView fov;

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        float rotateZ = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + 90);

        fov.SetAimDirection(direction);

        Vector3 localScale = Vector3.one;
        if(rotateZ > 90 || rotateZ < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        transform.localScale = localScale;
    }
}
