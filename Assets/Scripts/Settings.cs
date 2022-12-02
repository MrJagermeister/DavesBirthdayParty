using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Settings : MonoBehaviour
{
    public static bool Paused;
    public static bool Died;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject scoreCanvas;
    public GameObject spawner;
    public TextMeshProUGUI fallScoreText;
    public TextMeshProUGUI giftScoreText;
    public CinemachineVirtualCamera cm;
    private Transform player;
    public GameObject fadeOut;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameOverMenu.SetActive(false);
        Died = false;
        ScoreCounter.maxScore = 0;
        ScoreCounter.currentScore = 0;
        ScoreCounter.giftScore = 0;
    }

    void Update()
    {
        PauseMenu();
        GameOverMenu();
    }

    void GameOverMenu()
    {
        if (Died)
        {
            spawner.SetActive(false);
            scoreCanvas.SetActive(false);
            gameOverMenu.SetActive(true);
            cm.Follow = null;
            fallScoreText.text = "Meters Fallen: " + ScoreCounter.maxScore.ToString();
            giftScoreText.text = "Gifts Collected: " +ScoreCounter.giftScore.ToString();
        }
        else
        {
            spawner.SetActive(true);
            scoreCanvas.SetActive(true);
            gameOverMenu.SetActive(false);
            //cm.Follow = player;
        }
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Died)
            {
                if (!Paused)
                {
                    Paused = true;
                }
                else
                {
                    Paused = false;
                }
            }
        }

        if (Paused == true)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void Restart()
    {
        fadeOut.SetActive(true);
        Invoke("restartGame", 1f);
    }

    void restartGame()
    {
        Died = false;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
