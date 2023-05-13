using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    public static ScoreTextScript instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public int currentScore = 0;
    public int highScore = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "Score: " + currentScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void IncreaseScore(int s) 
    {
        currentScore += s;
        scoreText.text = "Score: " + currentScore.ToString();
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
    }
}
