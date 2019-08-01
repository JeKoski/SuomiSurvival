using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimater : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameplayMechanics gpm;

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

        if (gpm.playerInWater)
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Walking"), 0f);
            animator.SetLayerWeight(animator.GetLayerIndex("Swimming"), 1f);
        }

        else if (!gpm.playerInWater)
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Walking"), 1f);
            animator.SetLayerWeight(animator.GetLayerIndex("Swimming"), 0f);
        }
    }
}
