using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementDirection;
    //public GameObject player;
    public Rigidbody2D playerRB;

    public float movementSpeedMult = 1.0f;
    public float movementSpeed;
    public float sprintMult = 1.0f;
    
    void Awake()
    {
        
    }

    
    void Update()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintMult = 2.0f;
        }

        else
        {
            sprintMult = 1.0f;
        }

        // new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0)

        playerRB.velocity = movementDirection * movementSpeed * movementSpeedMult * sprintMult;
    }
}
