using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

	// Update is called once per frame
	void Update () {
        //Input.GetKey(KeyCode.LeftArrow
        //Debug.Log (Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log(Input.GetButtonDown("Jump"));
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {

            jump = true;
            animator.SetBool("isJump", true);
        }

    }
    public void OnLanding()
    {
        animator.SetBool("isJump", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
