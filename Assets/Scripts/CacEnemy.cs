using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CacEnemy : MonoBehaviour {

    /* IA Zone */
    SkeletonAnimation anim;
    Rigidbody2D body;

    /* Load Attack*/
    float periodeLoad = 0.8f;
    float timerLoad;
    bool isLoading = false;

    /* Following Attack*/
    bool isFollowing = false;
    float periodeFollowing = 1.0f;
    float timerFollowing;

    /* Impact Attack*/
    float timerImpact;
    float periodeImpact = 2.0f;

    /* Cible */
    Vector2 trajectPos;
    Vector2 movement;
    float speed = 5.0f;

    /* Player Zone */
    PlayerController scriptPlayer;


    // Use this for initialization
    void Start ()
    {
        scriptPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        anim = GetComponent<SkeletonAnimation>();
        body = GetComponent<Rigidbody2D>();
        trajectPos = (scriptPlayer.getPosition() - transform.position).normalized;
        body = GetComponent<Rigidbody2D>();
        timerLoad = periodeLoad;
        timerFollowing = periodeFollowing;
        timerImpact = periodeImpact;
    }

    void loadAttack()
    {
        anim.loop = false;
        anim.AnimationName = "AttackCharge";
        isLoading = true;
    }

    void getTarget()
    {
        trajectPos = (scriptPlayer.getPosition() - transform.position).normalized;
        move();
    }

    private void move()
    {
        anim.AnimationName = "AttackLoop";
        movement = new Vector2(speed * trajectPos.x, speed * trajectPos.y);
        body.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            loadAttack();
        }
    }

    private void resetImpact()
    {
        timerImpact = periodeImpact;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (timerImpact <= 0)
            {
                anim.AnimationName = "AttackImpact";
                scriptPlayer.loseLife();
                resetImpact();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (isLoading)
        {
            timerLoad -= Time.deltaTime;
        }

        if (timerLoad <= 0)
        {
            isLoading = false;
            timerLoad = periodeLoad;
            isFollowing = true;
        }

        if (isFollowing)
        {
            timerFollowing -= Time.deltaTime;
            getTarget();
        }

        if (timerFollowing <= 0.0f)
        {
            isFollowing = false;
            timerFollowing = periodeFollowing;
        }
    }
}
