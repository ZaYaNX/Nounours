using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;

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
        animator = GetComponent<Animator>();
        playerPhysicScript = GetComponentInChildren<PlayerController>();
        animPlayer = GetComponent<SkeletonAnimation>();
    }


    void Update()
    {
        playerSpeed = playerPhysicScript.getSpeed();
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        {
            if (playerSpeed.x > 0) //RIGHT
            {
                animPlayer.AnimationName = "walk_right_ac_nounours";
            }

            if (playerSpeed.x < 0) //LEFT
            {
                animPlayer.AnimationName = "walk_left_ac_nounours";
            }

            if (playerSpeed.y > 0) //TOP
            {
                animPlayer.AnimationName = "walk_up_ac_nounours";
            }

            if (playerSpeed.y < 0) //DOWN
            {
                animPlayer.AnimationName = "walk_down_ac_nounours";
            }

            if (playerSpeed.x == 0 && playerSpeed.y == 0)
            {
                animPlayer.AnimationName = "idle_ac_nounours";
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            if (playerSpeed.x > 0)
            {
                animPlayer.AnimationName = "walk_right";
            }

            if (playerSpeed.x < 0)

            {
                animPlayer.AnimationName = "walk_left";
            }

            if (playerSpeed.y > 0)

            {
                animPlayer.AnimationName = "walk_up";
            }

            if (playerSpeed.y < 0)

            {
                animPlayer.AnimationName = "walk_down";
            }

            if (playerSpeed.x == 0 && playerSpeed.y == 0)

            {
                animPlayer.AnimationName = "idle";
            }
        }
            
    }
}
