using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static bool isGameOver;
    public static bool isPaused;
    public static bool keyPressed;
    public static bool isWon;
    public static bool isLost;
    public AudioSource bgMusic;
    public GameObject gameOverScreen;
    public GameObject pressKeyScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject gamePausedScreen;
    public GameObject goldenKey;
    public GameObject blueKey;
    public static int keysCollected;
    public static int[] gemsCollected;
    public GameObject[] gemsUI = new GameObject[3];

    private void Awake()
    {
        Time.timeScale = 1;
        isPaused = false;
        isGameOver = false;
        isWon = false;
        isLost = false;
        keyPressed = true;
        keysCollected = 0;
        gemsCollected = new int[3];
    }

    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            bgMusic.Stop();
            gamePausedScreen.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            bgMusic.Stop();
            Time.timeScale = 0;
        }

        if (keyPressed) 
        {
            pressKeyScreen.SetActive(false);
        }
        else
        {
            pressKeyScreen.SetActive(true);
        }

        if (isWon)
        {
            bgMusic.Stop();
            winScreen.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }
        if (isLost)
        {
            bgMusic.Stop();
            loseScreen.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }

        if (keysCollected == 1) goldenKey.SetActive(true);
        if (keysCollected == 2) blueKey.SetActive(true);

        if (gemsCollected[0] == 1) gemsUI[0].SetActive(true);
        if (gemsCollected[1] == 1) gemsUI[1].SetActive(true); 
        if (gemsCollected[2] == 1) gemsUI[2].SetActive(true);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResumeGame()
    {
        gamePausedScreen.SetActive(false);
        Time.timeScale = 1;
        bgMusic.Play();
        isPaused = false;
    }
}
