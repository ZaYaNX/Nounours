using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class DistanceEnemy : MonoBehaviour
{
    /* Player Zone S*/
    PlayerController playerScript;
    Vector2 playerPosition;

    /* IA Zone */
    float xVision = 5.0f;
    float yVision = 5.0f;
    SkeletonAnimation animIa;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>() as PlayerController;
        animIa = GetComponent<SkeletonAnimation>();
    }

    private void checkPlayer()
    {
        if (playerPosition.x > 0)
        {
            playerPosition = new Vector2(playerPosition.x * -1, playerPosition.y);
        }

        if (playerPosition.y > 0)
        {
            playerPosition = new Vector2(playerPosition.x, playerPosition.y * -1);
        }

        Debug.Log((transform.position.x - playerPosition.x));

        if ((transform.position.x - playerPosition.x) > xVision)
        {
            
            animIa.loop = false;
            animIa.AnimationName = "AttackDown";
        }

        if ((transform.position.y - playerPosition.y) > yVision)
        {
            animIa.loop = false;
            animIa.AnimationName = "AttackDown";
        }
    }

    private void Update()
    {
        playerPosition = playerScript.getPosition();
        checkPlayer();
    }

}