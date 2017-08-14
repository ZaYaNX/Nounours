using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematique : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer image1;
    float imageDisabledTimer;
    float imageDisabledPeriod;
    string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Cinematique0")
        {
            imageDisabledPeriod = 3f;
        }
        if(currentScene == "Cinematique1")
        {
            imageDisabledPeriod = 0.5f;
        }
    }

    void Update()
    {
        imageDisabledTimer += Time.deltaTime;
        if (imageDisabledTimer >= imageDisabledPeriod && currentScene == "Cinematique1")
        {
            image1.enabled = false;
        }
        if(currentScene == "Cinematique0" && imageDisabledTimer >= imageDisabledPeriod)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}