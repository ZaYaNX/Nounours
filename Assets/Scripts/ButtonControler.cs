using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour
{
    [SerializeField]
    Sprite buttonSelectedSprite;
    [SerializeField]
    Sprite buttonUnSelectedSprite;

    public void loadScene(int newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void selectedButton(GameObject button)
    {
        button.GetComponent<Image>().sprite = buttonSelectedSprite;
    }

    public void unSelectedButton(GameObject button)
    {
        button.GetComponent<Image>().sprite = buttonUnSelectedSprite;
    }

    public void exitGameBtn()
    {
        Application.Quit();
    }

}
