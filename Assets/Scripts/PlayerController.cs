using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementDirection;
    public Rigidbody2D playerRB;
    private bool pFacingRight;
    public GameplayVariables gpv;

    [Header("Player Movement Speed Settings")]

    [Tooltip("Base movement speed for the player. Default: 5.0")]
    [SerializeField] private float movementSpeedMult = 5.0f;

    [Tooltip("Movement speed multiplied by this when player is sprinting. Default: 2.0")]
    [SerializeField] private float sprintOnMult = 2.0f;

    //[Tooltip("Speed multiplier when coffee is out")]
    //[SerializeField] private float coffeeOutSpeedMult = 0.5f;
    //private float coffeeOutSpeedMultDefault = 0.5f;

    [Space]

    [Header("Visible for debugging. Don't change these.")]

    [Tooltip("Current movement speed")]
    public float movementSpeed;

    public bool playerSprinting = false;

    [Tooltip("Current sprinting multiplier. Default: 1.0")]
    [SerializeField] private float sprintMult = 1.0f;

    [Tooltip("Multiplier when not sprinting. Default: 1.0")]
    [SerializeField] private float sprintOffMult = 1.0f;
    
    
    void Awake()
    {
        
    }

    
    void Update()
    {
        MoveWithDisableCheck();
        //ProcessInputs();
        //Move();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        //if (movementDirection.x > 0 && pFacingRight)
        //{
        //    FlipPlayer();
        //}

        //else if (movementDirection.x < 0 && !pFacingRight)
        //{
        //    FlipPlayer();
        //}
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift) && gpv.playerCoffee > 0)
        {
            sprintMult = sprintOnMult;
            playerSprinting = true;
        }

        else
        {
            sprintMult = sprintOffMult;
            playerSprinting = false;
        }

        playerRB.velocity = movementDirection * movementSpeed * movementSpeedMult * sprintMult;
    }

    void MoveWithDisableCheck()
    {
        if (!gpv.inputsDisabled)
        {
            ProcessInputs();
            Move();
        }

        else if (gpv.inputsDisabled)
        {
            playerRB.velocity = new Vector2(0,0);
        }
    }

    //void FlipPlayer()
    //{
    //    pFacingRight = !pFacingRight;

    //    Vector3 playerScale = transform.localScale;
    //    playerScale.x *= -1;
    //    transform.localScale = playerScale;
    //}
}
