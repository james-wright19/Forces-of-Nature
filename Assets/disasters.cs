using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class disasters : MonoBehaviour
{   
    public static disasters current;
    public GameObject tornadoPrefab;
    public GameObject FireParticlesPrefab;
    public GameObject floodWater;
    public GameObject player;
    private bool cameraShake = false;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraShake)
        {
            // Camera Shake Scripts

            if (count < 200)
            {
                if (count % 2 == 0)
                {
                    float rx = Random.Range(-2f, 2f);
                    float ry = Random.Range(-2f, 2f);

                    gameObject.transform.position = new Vector3(player.transform.position.x + rx, player.transform.position.y + ry, -10);
                }

                count++;
            } else
            {
                cameraShake = false;
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
        } else
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }

    [ContextMenu("summonTornado")]
    public void WindDisaster()
    {
        Score.current.AddScore(100);
        GameObject tornado = Instantiate(tornadoPrefab);

        tornado.transform.position = new Vector3(player.transform.position.x - 10, player.transform.position.y, 0);
    }

    [ContextMenu("summonFire")]
    public void FireDisaster()
    {
        Score.current.AddScore(100);
        spawnFireEffect();
        spawnFireEffect();
        spawnFireEffect();
        spawnFireEffect();
        spawnFireEffect();
    }

    private void spawnFireEffect()
    {
        int rx = Random.Range(-20, 25);
        int ry = Random.Range(0, 10);
        Vector3 vec = new Vector3(rx, ry, 0);
        GameObject fireParticles = Instantiate(FireParticlesPrefab);
        fireParticles.transform.position = vec;
    }

    [ContextMenu("summonWater")]
    public void WaterDisater()
    {
        Score.current.AddScore(100);
        GameObject flood = Instantiate(floodWater);
    }

    [ContextMenu("summonEarthquake")]
    public void EarthDisater()
    {
        Score.current.AddScore(100);
        count = 0;
        cameraShake = true;

    }
}
