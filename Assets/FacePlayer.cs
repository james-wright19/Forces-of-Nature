using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    bool lookingRight = false;

    void Update()
    {
        Face();
    }
    void Face()
    {
        bool flip = false;
        Vector3 playerPosition = Player.currentPlayer.transform.position ;

        Vector2 direction = new Vector2(
            playerPosition.x - transform.position.x,
            playerPosition.y - transform.position.y
            );
        transform.right = direction * -1;
        if (Player.currentPlayer.transform.position.x < gameObject.transform.position.x && lookingRight == false)
        {
            flip = true;
            lookingRight = true;
        }
        else if (Player.currentPlayer.transform.position.x > gameObject.transform.position.x && lookingRight == true)
        {
            flip = true;
            lookingRight = false;
        }
        if (flip == true)
        {
            Vector3 vector3 = gameObject.transform.localScale;
            vector3.y *= -1;
            gameObject.transform.localScale = vector3;
        }
    }

}
