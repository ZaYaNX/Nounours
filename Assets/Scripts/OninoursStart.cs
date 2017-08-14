using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OninoursStart : MonoBehaviour {

    float IntroTimer;
    const float IntroPeriod = 1.7f;

	
	void Start () {

	}
	
	
	void Update ()
    {
        IntroTimer += Time.deltaTime;
        if (IntroTimer >= IntroPeriod)
        {
            SceneManager.LoadScene(1);
        }
	}
}
