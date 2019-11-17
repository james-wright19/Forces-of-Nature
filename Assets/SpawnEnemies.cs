using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject fireE;
    public GameObject earthE;
    public GameObject waterE;
    public GameObject windE;
    float timer = 0.0f;
    int timeBetween = 10;
    int lastSpawn;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);

        if (seconds % timeBetween == 0 && lastSpawn != seconds)
        {
            int spawnNum = Random.Range(0, 4);

            if (spawnNum == 1)
            {
                spawnFire();
            }
            else if (spawnNum == 2)
            {
                spawnEarth();
            }
            else if (spawnNum == 3)
            {
                spawnWater();
            }
            else if (spawnNum == 0)
            {
                spawnWind();
            }

            int rand = Random.Range(0, 1);
            timeBetween += rand;
            lastSpawn = seconds;
        }
    }

    public void spawnFire()
    {
        GameObject fireEn = Instantiate(fireE);

        fireEn.transform.position = new Vector3(-2, 10, 0);
    }

    public void spawnEarth()
    {
        GameObject earthEn = Instantiate(earthE);

        earthEn.transform.position = new Vector3(-12, -2, 0);
    }

    public void spawnWater()
    {
        GameObject waterEn = Instantiate(waterE);

        waterEn.transform.position = new Vector3(2, -2, 0);
    }

    public void spawnWind()
    {
        GameObject windEn = Instantiate(windE);

        windEn.transform.position = new Vector3(23, 5, 0);
    }
}