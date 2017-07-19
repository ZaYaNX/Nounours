using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    bool keyHold = false;

    void Update() // Filipe doit me taper
    {
        Debug.Log(keyHold);
        if (Input.GetKeyDown(KeyCode.E) && currentInterObj != null)
        {
            keyHold = true;
            Destroy(currentInterObj);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteracObject"))
        {
            currentInterObj = other.gameObject;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Door") && keyHold)
        {
            SceneManager.LoadScene("Cinematique1");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InteracObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}