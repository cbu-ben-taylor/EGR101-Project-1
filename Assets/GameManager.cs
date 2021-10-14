using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public Text HighScores;

    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;

        for (int hiScore = 1; hiScore <= 10; hiScore++)
        {
            if (PlayerPrefs.GetInt("score" + hiScore) < 1)
            {
                PlayerPrefs.SetInt("score" + hiScore, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
            EndGame();

        if (PlayerCombat.currentHealth <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);

        // Find if current score is higher than a current Hi Score
        for (int i = 1; i <= 10; i++)
        {
            if (ScoreUI.score > PlayerPrefs.GetInt("score" + i))
            {
                // If found, bump each score below it down one position and add new Hi Score
                for (int j = 10; j > (i); j--)
                {
                    PlayerPrefs.SetInt("score" + j, PlayerPrefs.GetInt("score" + (j - 1)));
                }
                PlayerPrefs.SetInt("score" + i, ScoreUI.score);
                break;
            }
        }

        HighScores.text = "High Scores:\n"
                        + PlayerPrefs.GetInt("score1").ToString() + "\n"
                        + PlayerPrefs.GetInt("score2").ToString() + "\n"
                        + PlayerPrefs.GetInt("score3").ToString() + "\n"
                        + PlayerPrefs.GetInt("score4").ToString() + "\n"
                        + PlayerPrefs.GetInt("score5").ToString() + "\n"
                        + PlayerPrefs.GetInt("score6").ToString() + "\n"
                        + PlayerPrefs.GetInt("score7").ToString() + "\n"
                        + PlayerPrefs.GetInt("score8").ToString() + "\n"
                        + PlayerPrefs.GetInt("score9").ToString() + "\n"
                        + PlayerPrefs.GetInt("score10").ToString();

    }
}
