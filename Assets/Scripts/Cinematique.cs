using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer image1;
    float imageDisabledTimer;
    const float imageDisabledPeriod = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        imageDisabledTimer += Time.deltaTime;
        if (imageDisabledTimer >= imageDisabledPeriod)
        {
            image1.enabled = false;
        }
    }
}