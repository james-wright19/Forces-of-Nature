using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 100;

    public GameObject deathEffect;
    public Animator animator;

    public void TakeDamage(int damage) {
        health -= damage;
   
        animator.SetBool("damage", true);
        if (health <= 0) {
            Die();
        }
        animator.SetBool("damage", false);
        
    }
    void Die() {

        //Instantiate(deathEffect, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }







	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        Score.current.AddScore(50);
    }
}
