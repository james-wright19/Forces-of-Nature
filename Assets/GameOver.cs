using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver current;
    public bool isGameOver = false;

    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI reasonOfFailure;
    public TMPro.TextMeshProUGUI score;

    void Start()
    {
        current = this;
    }
    
    void Update()
    {
        if(Player.currentPlayer.GetComponent<Player>().health <= 0)
        {
            OnGameOver("Player died.");
        }
    }

    public void OnGameOver(string reason)
    {
        if(!isGameOver)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            this.enabled = false;
            reasonOfFailure.text = "Reason of failure:\n" + reason;
            score.text = "Final score:\n" + Score.current.score;
        }
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
