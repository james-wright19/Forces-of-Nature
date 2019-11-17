using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flood : MonoBehaviour
{
    private int count = 0;
    private bool turn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == false)
        {
            gameObject.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);


            if (gameObject.transform.position.y > -7)
            {
                turn = true;
            }
        } else
        {
            if (count > 1000)
            {
                count++;
            } else
            {
                gameObject.transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.currentPlayer.GetComponent<Player>().TakeDamage(1);
        }
        if (collision.tag == "Fire")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.currentPlayer.GetComponent<Player>().TakeDamage(1);
        }
    }
}
