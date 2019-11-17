using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.currentPlayer.GetComponent<Player>().TakeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.currentPlayer.GetComponent<Player>().TakeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Destroy(collision2D.otherCollider);
    }
}
