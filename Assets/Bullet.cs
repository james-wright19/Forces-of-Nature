using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public float decay = 1f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    

	// Use this for initialization
	void Start () {
        Destroy(gameObject,decay);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.right * speed;

	}

    void OnTriggerEnter2D(Collider2D hitinfo) {
        Debug.Log(hitinfo.name);
        
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
