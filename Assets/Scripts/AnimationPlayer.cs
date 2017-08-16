using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimationPlayer : MonoBehaviour
{
    /* PLAYER */
    PlayerController playerPhysicScript;
    Vector2 playerSpeed;

    private Animator animator;

    [SerializeField]
    SkeletonAnimation animPlayer;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerPhysicScript = GetComponentInChildren<PlayerController>();
        animPlayer = GetComponent<SkeletonAnimation>();
    }


    void Update()
    {
        playerSpeed = playerPhysicScript.getSpeed();

        if (playerSpeed.x > 0) //RIGHT
        {
            animPlayer.AnimationName = "walk_right_ac_nounours";
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

        if (playerSpeed.x == 0 && playerSpeed.y == 0)
        {
            animPlayer.AnimationName = "idle_ac_nounours";
        }
    }
}
