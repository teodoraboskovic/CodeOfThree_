using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gameOver = false;
    public GameObject gameOverText;
    public GameObject ruleBrokenText;
    public GameObject replayButton;
    public GameObject winText;
    public GameObject mainMenuButton;
    public GameObject congratulationsText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        ruleBrokenText.SetActive(false);
        replayButton.SetActive(false);
        winText.SetActive(false);
        mainMenuButton.SetActive(false);
        congratulationsText.SetActive(false);
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void RuleBroken()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Rule is broken!");
            EndGame();
        }
    }
    void EndGame()
    {
        gameOverText.SetActive(true);
        replayButton.SetActive(true);
        ruleBrokenText.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void WinGame()
    {
        gameOver = true;
        winText.SetActive(true);
        mainMenuButton.SetActive(true);
        congratulationsText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}

