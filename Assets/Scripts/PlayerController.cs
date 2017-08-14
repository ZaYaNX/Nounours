using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Spine.Unity;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    bool mvHoz = false;
    bool mvVer = false;

    /* LIFE */
    [SerializeField]
    SkeletonAnimation animLife1;
    [SerializeField]
    SkeletonAnimation animLife2;
    [SerializeField]
    SkeletonAnimation animLife3;

    /* BODY */
    Rigidbody2D body;
    Vector2 velocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < -0f)
        {

            if (!mvVer)
            {
                body.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, 0f);
                mvHoz = true;
            }

        }
        else
        {
            mvHoz = false;
        }

        if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            body.velocity = new Vector3(0.0f, body.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < -0f)
        {
            if (!mvHoz)
            {
                body.velocity = new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed, 0f);
                mvVer = true;
            }

        }
        else
        {
            mvVer = false;
        }

        if (Input.GetAxisRaw("Vertical") == 0f)
        {
            body.velocity = new Vector3(body.velocity.x, 0.0f);
        }
    }

    private void loseLife()
    {
        if (animLife1.loop)
        {
            animLife1.loop = false;
            animLife1.AnimationName = "lose_heart";
        }
        else if (animLife2.loop)
        {
            animLife2.loop = false;
            animLife2.AnimationName = "lose_heart";
        }
        else if (animLife3.loop)
        {
            animLife3.loop = false;
            animLife3.AnimationName = "lose_heart";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("IA"))
        {
            loseLife();
        }
    }

    public Vector2 getSpeed()
    {
        velocity = body.velocity;
        return body.velocity;
    }

}