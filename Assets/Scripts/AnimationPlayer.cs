using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    /* PLAYER */
    PlayerController playerPhysicScript;
    Vector2 playerSpeed;

    private Animator animator;


    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerPhysicScript = GetComponentInChildren<PlayerController>();
    }


    void Update()
    {
        playerSpeed = playerPhysicScript.getSpeed();

        if (playerSpeed.x > 0) //RIGHT
        {
            animator.SetBool("walk_right", true);
        }

        if (playerSpeed.x < 0) //LEFT
        {
            animator.SetBool("walk_left", true);
        }

        if (playerSpeed.y > 0) //TOP
        {
            animator.SetBool("walk_up", true);
        }

        if (playerSpeed.y < 0) //DOWN
        {
            animator.SetBool("walk_down", true);
        }

        if (playerSpeed.x == 0)
        {
            animator.SetBool("walk_right", false);
            animator.SetBool("walk_left", false);
        }

        if (playerSpeed.y == 0)
        {
            animator.SetBool("walk_up", false);
            animator.SetBool("walk_down", false);
        }
    }
}
