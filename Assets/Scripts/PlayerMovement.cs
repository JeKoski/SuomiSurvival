using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Rigidbody2D playerRigidbody;

    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float maxMovementSpeed = 5.0f;
    [SerializeField] private float reducedMovementSpeed = 0.5f;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void MovePlayer()
    {
        //playerRigidbody.velocity = new Vector2(movementSpeed, playerRigidbody.velocity.y);


    }
}
