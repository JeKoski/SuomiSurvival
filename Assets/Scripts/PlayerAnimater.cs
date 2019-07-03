using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimater : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerController playerController;


    private void Update()
    {
        Animate();
    }

    void Animate()
    {
        if (playerController.movementDirection != Vector2.zero)
        {
        animator.SetFloat("Horizontal", playerController.movementDirection.x);
        animator.SetFloat("Vertical", playerController.movementDirection.y);

        }
        
        animator.SetFloat("Speed", playerController.movementSpeed);
    }
}
