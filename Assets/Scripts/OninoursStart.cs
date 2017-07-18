﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OninoursStart : MonoBehaviour {

    float IntroTimer;
    const float IntroPeriod = 3f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        IntroTimer += Time.deltaTime;
        if (IntroTimer >= IntroPeriod)
        {
            SceneManager.LoadScene(1);
        }
	}
}
