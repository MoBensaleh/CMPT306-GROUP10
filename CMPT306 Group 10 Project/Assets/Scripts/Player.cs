using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Default movement speed
    public float movementSpeed = 3f;    // default value

    public GridMap areas;

    Rigidbody2D rbody;

    Vector2 currentPos;
    Vector2 inputVector;
    Vector2 movement;
    Vector2 newPos;

    float horizontalInput, verticalInput;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // currentPos = rbody.position;

        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");

        // inputVector = new Vector2(horizontalInput, verticalInput);
        // inputVector = Vector2.ClampMagnitude(inputVector, 1);

        // movement = inputVector * movementSpeed;
        // newPos = currentPos + movement * Time.fixedDeltaTime;

        // if (areas.RetrieveState(newPos).unblocked) {
        //     rbody.MovePosition(newPos);
        //     }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        rbody.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class IsometricPlayerMovementController : MonoBehaviour
// {

//     // Default movement speed
//     public float movementSpeed = 3f;    // default value

//     public GridMap areas;

//     Rigidbody2D rbody;

//     Vector2 currentPos;
//     Vector2 inputVector;
//     Vector2 movement;
//     Vector2 newPos;

//     float horizontalInput, verticalInput;

//     private void Awake()
//     {
//         rbody = GetComponent<Rigidbody2D>();
//     }


//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         currentPos = rbody.position;

//         horizontalInput = Input.GetAxis("Horizontal");
//         verticalInput = Input.GetAxis("Vertical");

//         inputVector = new Vector2(horizontalInput, verticalInput);
//         inputVector = Vector2.ClampMagnitude(inputVector, 1);

//         movement = inputVector * movementSpeed;
//         newPos = currentPos + movement * Time.fixedDeltaTime;

//         if (areas.RetrieveState(newPos).unblocked) rbody.MovePosition(newPos);
//     }
// }

// public class Player : MonoBehaviour
// {
//     public float speed = 5;
//     float xMovement, yMovement;
//     public GridMap areas;
//     Vector3 newLocation;

//     void Update()
//     {
//         xMovement = Input.GetAxis("Horizontal");
//         yMovement = Input.GetAxis("Vertical");
//         newLocation = transform.position + new Vector3(xMovement, yMovement, 0) * speed * Time.deltaTime;
//         if (areas.RetrieveState(newLocation).unblocked) transform.position = newLocation;
//     }
// }

// using UnityEngine.EventSystems;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 25.0f;
//     public Rigidbody2D rb;
//     private Vector2 moveDirection;

//     // Update is called once per frame
//     void Update()
//     {
//         // Input
//         ProcessInputs();

//     }

//     private void FixedUpdate()
//     {
//         // Movement
//         Move();
//     }

//     void ProcessInputs()
//     {
//         float moveX = Input.GetAxisRaw("Horizontal");
//         float moveY = Input.GetAxisRaw("Vertical");

//         moveDirection = new Vector2(moveX, moveY).normalized;
//     }

//     void Move()
//     {
//         rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
//     }
// }
