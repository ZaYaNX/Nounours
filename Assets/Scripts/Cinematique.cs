using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cinematique : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer image1;
    [SerializeField]
    SpriteRenderer image2;
    [SerializeField]
    SpriteRenderer image3;
    float imageDisabledTimer;
    float imageDisabledPeriod;
    string currentScene;
    bool LoadLevel2;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Cinematique0")
        {
            imageDisabledPeriod = 3f;
        }
        if (currentScene == "Cinematique1")
        {
            imageDisabledPeriod = 0.5f;
        }

        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Cinematique2")
        {
            imageDisabledPeriod = 2f;
        }


    }

    void Update()
    {
        imageDisabledTimer += Time.deltaTime;
        if (imageDisabledTimer >= imageDisabledPeriod && currentScene == "Cinematique1")
        {           
            StartCoroutine(cinématique1());
        }
        if (currentScene == "Cinematique0" && imageDisabledTimer >= imageDisabledPeriod)
        {
            SceneManager.LoadScene("Level1");      
        }      
    }

    IEnumerator cinématique1()
    {
        image1.enabled = false;
        yield return new WaitForSeconds(2);
        image2.enabled = false;
        yield return new WaitForSeconds(2);
        image3.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator cinématique_04()
    {
        image1.enabled = false;
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("menu");
    }
}
