using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectKey;
    [SerializeField]
    GameObject gameObjectPlanche;

    public GameObject currentInterObj = null;
    bool keyHold = false;
    bool plancheHold = false;
    [SerializeField]
    BoxCollider2D hole;
    [SerializeField]
    GameObject planche;

    private void Start()
    {
        gameObjectKey.SetActive(false);
        gameObjectPlanche.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteracObject"))
        {
            currentInterObj = other.gameObject;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Item") && currentInterObj != null)
        {
            if (currentInterObj.name.Contains("clef"))
            {
                gameObjectKey.SetActive(true);
                keyHold = true;
            }
            if (currentInterObj.name.Contains("Bois"))
            {
                gameObjectPlanche.SetActive(true);
                plancheHold = true;
            }
            Destroy(currentInterObj);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Door") && keyHold)
        {
            SceneManager.LoadScene(4);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("hole") && plancheHold)
        {
            hole.enabled = false;
            planche.SetActive(true);
            plancheHold = false;
            gameObjectPlanche.SetActive(false);
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
    void Update()
    {

    }
}
