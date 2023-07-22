using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject timer;
    public GameObject gameOverPanel;

    public GameObject enemySpawn;

    private enemySpawn spawnScript;
    void Start()
    {
        gameOverPanel.SetActive(false);
        spawnScript = enemySpawn.GetComponent<enemySpawn>();
    }

    public void resumeGame() { }
    public void pauseGame() { }
    public void gameOver() 
    {
        gameOverPanel.SetActive(true);
        spawnScript.spawnRate = 0; 
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
