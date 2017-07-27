using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    bool mvHoz;
    bool mvVer;




    void Start()
    {

    }

    void Update()
    {

      if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < -0f)
          {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
          }
          if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < -0f)
          {
              transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
          }



    }
    
}