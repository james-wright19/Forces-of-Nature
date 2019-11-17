using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static GameObject currentPlayer;
    public int health = 100;
    public Image healthBar;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {

        //Instantiate(deathEffect, transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        if (!currentPlayer)
        {
            currentPlayer = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100f;
    }
}
