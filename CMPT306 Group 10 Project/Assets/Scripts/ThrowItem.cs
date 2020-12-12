using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    //This is for item rotating with player
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    private Vector3 mousePos;

    public const float Max_Force = 500f;
    public void Launch(float force)
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.GetComponent<Rigidbody2D>().velocity = lookPos * force;
        //HideForce();
    }

    public void ShowForce(float force)
    {

    }

    //[SerializeField] private Item item;


    // Update is called once per frame
    void Update()
    {

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Throw readied!");
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.Launch(4f);
            Debug.Log("YEET!");
        }

    }
}
