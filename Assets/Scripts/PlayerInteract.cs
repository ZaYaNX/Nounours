using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectKey;

    public GameObject currentInterObj = null;
    bool keyHold = false;

    private void Start()
    {
        gameObjectKey.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteracObject"))
        {
            currentInterObj = other.gameObject;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Door") && keyHold)
        {
            SceneManager.LoadScene(4);
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

    void Update() // Filipe doit me taper
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInterObj != null)
        {
            keyHold = true;
            gameObjectKey.SetActive(true);
            Destroy(currentInterObj);
        }
    }
}