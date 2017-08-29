using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class DistanceEnemy : MonoBehaviour
{
    /* IA Zone */
    float yVision = 5.0f;
    SkeletonAnimation animIa;
    float timerAnimAttack = 2.0f;
    bool canTimerAttackDown = false;

    /* Fire */
    [SerializeField]
    GameObject prefabFire;

    private void Start()
    {
        animIa = GetComponent<SkeletonAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animIa.loop = false;
            animIa.AnimationName = "AttackDown";
            canTimerAttackDown = true;
        }
    }

    private void Update()
    {
        if (canTimerAttackDown)
        {
            timerAnimAttack -= Time.deltaTime;
        }

        if (timerAnimAttack <= 0)
        {
            timerAnimAttack = 2.0f;
            canTimerAttackDown = false;
            Instantiate(prefabFire, transform.position, transform.rotation);
            animIa.loop = true;
            animIa.AnimationName = "IDLE";
        }
    }
}