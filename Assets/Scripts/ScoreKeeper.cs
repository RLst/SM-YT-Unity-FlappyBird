using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    const string HISCORE_KEY = "hiscore";

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public UnityEvent onIncrementScore;

    int score;

    void Start()
    {
        ResetScore();
        UpdateScoreUI();
    }

    void ResetScore()
    {
        score = 0;
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();

        //If the hiscore is lower than the current score
        if (PlayerPrefs.GetInt(HISCORE_KEY, 0) < score)
        {
            PlayerPrefs.SetInt(HISCORE_KEY, score);
            PlayerPrefs.Save(); 
        }
        hiscoreText.text = "Hi-Score: " + PlayerPrefs.GetInt(HISCORE_KEY, 0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //If we DIDN'T hit an obstacle then ignore
        if (!other.GetComponent<Obstacle>())
            return;

        //If we hit an obstacle...
        IncrementScore();
        UpdateScoreUI();
    }

    void IncrementScore()
    {
        score++;

        onIncrementScore.Invoke();
    }
}
