using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FieldOfView fov;
    private float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    //Mac 2020-11-11
    public Camera cam;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = viewCamera.
        // Input
        //ProcessInputs(); //Uncomment for original, Mac 2020-11-11
        //transform.LookAt(mouseP)

        //Mac 2020-11-11
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition).normalized;

    }

    private void FixedUpdate()
    {
        // Movement
        // Move(); //Uncomment for original, Mac 2020-11-11
        
        //Mac 2020-11-11
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        fov.SetOrigin(transform.position);
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
      
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        fov.SetOrigin(transform.position);
    }
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
