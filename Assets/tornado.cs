using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{

    public Vector3 playerVec; 
        
    // Start is called before the first frame update
    void Start()
    {
        playerVec = Player.currentPlayer.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(playerVec.x , playerVec.y, 0)/10 * Time.deltaTime;


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


}
