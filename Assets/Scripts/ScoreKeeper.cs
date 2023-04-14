using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreKeeper : MonoBehaviour
{
    const string HISCORE_KEY = "hiscore";

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
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
        if (!other.GetComponent<Obstacle>())
            return;

        score++;
        UpdateScoreUI();
    }
}
