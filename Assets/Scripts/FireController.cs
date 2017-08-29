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

	// Update is called once per frame
	void Update ()
    {
        movement = new Vector2(speed * trajectPos.x, speed * trajectPos.y);
	}
}
