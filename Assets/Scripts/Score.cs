using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private string scoreType;
    private TMP_Text scoreText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreType == "highscore")
        {
            UpdateHighscore();
        }
        else
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = gameManager.score.ToString();
    }

    private void UpdateHighscore()
    {
        scoreText.text = "Highscore : " + gameManager.highScore.ToString();
    }
}
