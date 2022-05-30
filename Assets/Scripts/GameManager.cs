using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text sliderText;

    public float score;
    private float currentTime;
    public bool isReset;

    public float highScore;
    private float maxTime = 30f;

    private void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highscore", highScore);

        currentTime = maxTime;

        if (!slider) return;
        slider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highscore", highScore);
        }

        if (!slider) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, maxTime);
        slider.value = currentTime;
        sliderText.text = Mathf.FloorToInt(currentTime) + " s";

        if (currentTime <= 0 && !isReset)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
            isReset = true;
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void ResetGame()
    {
        score = 0;
        currentTime = maxTime;
        isReset = false;
    }

}
