using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour 
{
    public static Game_Controller instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI timeScore, finalScore;
    public bool isPlaying;

    public float startTime, elapsedTime;

    private string timeStr;

    TimeSpan playingTime;



    private void Start()
    {
        isPlaying = false;
        timeScore.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(isPlaying)
        {
            elapsedTime = Time.time - startTime;
            playingTime = TimeSpan.FromSeconds(elapsedTime);

            timeStr = playingTime.ToString("mm' : 'ss' : 'ff");
            timeScore.text = timeStr;
        }
    }

    public void Awake()
    {
        instance = this;
    }

    public void endGame()
    {
        isPlaying = false;
        timeScore.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        finalScore.text = timeStr;
    }

    public void startGame()
    {
        isPlaying = true;
        startTime = Time.time;
        timeScore.gameObject.SetActive(true);
    }

    public void onRestartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
