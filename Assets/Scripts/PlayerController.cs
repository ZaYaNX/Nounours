using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    bool mvHoz = false;
    bool mvVer = false;




    void Start()
    {

    }

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < -0f)
        {

            if (!mvVer)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                mvHoz = true;
            }

        }
        else
        {
            mvHoz = false;
        }

        if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < -0f)
        {
            if (!mvHoz)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                mvVer = true;
            }
            
        }
        else
        {
            mvVer = false;
        }



    }

}