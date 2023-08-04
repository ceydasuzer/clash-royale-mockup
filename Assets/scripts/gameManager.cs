using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using UnityEngine.AddressableAssets.ResourceLocators;

public class gameManager : MonoBehaviour
{
    [SerializeField] public GameObject timer;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] public GameObject enemySpawn;

  
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject downloadInfoTxt;

    [SerializeField] private AssetReference environment;

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


    public void DownloadFiles()
    {
       
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;

        void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
        {
            environment.InstantiateAsync();
        }
        Debug.Log("environment downloaded");

        downloadInfoTxt.SetActive(true);
        playButton.SetActive(true);
    }

    public void PlayButtonActivated()
    {
        Addressables.LoadSceneAsync("Game", LoadSceneMode.Single, true);
        Debug.Log("game loaded as addressable");
    }
}
