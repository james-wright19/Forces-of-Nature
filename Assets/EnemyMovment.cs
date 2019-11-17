using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {
    public float runSpeed = 20f;
    public int damage = 1;

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    
    bool jump = false;

    void Update()
    {
        float enemyTop = gameObject.transform.position.y + 0.042f;
        float playerBottom = Player.currentPlayer.transform.position.y - 0.817f;

        if (Player.currentPlayer.transform.position.x < gameObject.transform.position.x)
        {
            horizontalMove = -1 * runSpeed;
        }
        else if (Player.currentPlayer.transform.position.x > gameObject.transform.position.x)
        {
            horizontalMove = 1 * runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (playerBottom > enemyTop)
        {
            //Debug.Log(playerBottom + " " + enemyTop);
            //jump = true;
        }
    }
    public void OnLanding()
    {
        animator.SetBool("isJump", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
       
    }
    void OnTriggerStay2D(Collider2D hitinfo)
    {

        Object obj = hitinfo.GetComponent<Object>();
        if (obj != null)
        {
            jump = true;
            animator.SetBool("isJump", true);
        }
        Player player = hitinfo.GetComponent<Player>();
        if (player != null)
        {
            jump = false;
            player.TakeDamage(damage);
        }
    }


}
