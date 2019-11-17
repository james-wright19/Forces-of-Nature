using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score current;
    public int score;
    float secondTimer = 1;
    public TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        current = this;
    }
    private void Update()
    {
        scoreText.text = "Score:\n" + score;

        secondTimer -= Time.deltaTime;
        if(secondTimer < 0)
        {
            secondTimer = 1;
            AddScore(5);
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
    }
}
