using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

    /* Player zone */
    PlayerController scriptPlayer;

    /* Bullet */
    Vector2 trajectPos;
    Vector2 movement;
    float speed = 5.0f;
    Rigidbody2D body;

    /* Dammage Zone*/
    float timerDammage = 0.0f;
    float periodeDammage = 2.0f;

	// Use this for initialization
	void Start ()
    {
        scriptPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        trajectPos = (scriptPlayer.getPosition() - transform.position).normalized;
        body = GetComponent<Rigidbody2D>();
	}
	
    private void FixedUpdate()
    {
        body.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("touch");
            if (timerDammage <= 0)
            {
                scriptPlayer.loseLife();
                timerDammage = periodeDammage;
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        timerDammage -= Time.deltaTime;
        movement = new Vector2(speed * trajectPos.x, speed * trajectPos.y);
	}
}
