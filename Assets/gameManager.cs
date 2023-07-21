using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject timer;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void resumeGame() { }
    public void pauseGame() { }
    public void gameOver() 
    {
        gameOverPanel.SetActive(true);
        timer.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void backToMain()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
