using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {


    private Animator animator;


    void Start()

    {
        animator = this.GetComponent<Animator>();
    }


    void Update()

    {

        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            animator.SetBool("walk_up", true);
            animator.SetBool("wasFacingUp", true);
            animator.SetBool("wasFacingLeft", false);
            animator.SetBool("wasFacingRight", false);
            animator.SetBool("wasFacingDown", false);
        }
        else
        { animator.SetBool("walk_up", false); }

        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            animator.SetBool("walk_down", true);
            animator.SetBool("wasFacingUp", false);
            animator.SetBool("wasFacingLeft", false);
            animator.SetBool("wasFacingRight", false);
            animator.SetBool("wasFacingDown", true);
        }
        else { animator.SetBool("walk_down", false); }


        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            animator.SetBool("walk_left", true);
            animator.SetBool("wasFacingLeft", true);
            animator.SetBool("wasFacingUp", false);
            animator.SetBool("wasFacingRight", false);
            animator.SetBool("wasFacingDown", false);
        }
        else { animator.SetBool("walk_left", false); }


        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            animator.SetBool("walk_right", true);
            animator.SetBool("wasFacingLeft", false);
            animator.SetBool("wasFacingUp", false);
            animator.SetBool("wasFacingRight", true);
            animator.SetBool("wasFacingDown", false);
        }
        else { animator.SetBool("walk_right", false); }

    }
}
