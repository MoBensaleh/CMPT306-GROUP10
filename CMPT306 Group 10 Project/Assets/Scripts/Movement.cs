using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private FieldOfView fov;
    public float moveSpeed = 8.0f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();


    }

    private void FixedUpdate()
    {
        // Movement
        Move();

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
}
