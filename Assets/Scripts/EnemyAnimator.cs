using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator animator;
    public EnemyFollowAI enemyFollowAI;
    private void Update()
    {
        Animate();
    }

    void Animate()
    {
        if (enemyFollowAI.mDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", enemyFollowAI.mDirection.x);
            animator.SetFloat("Vertical", enemyFollowAI.mDirection.y);

        }

        animator.SetFloat("Speed", enemyFollowAI.enemySpeed);
    }
}

