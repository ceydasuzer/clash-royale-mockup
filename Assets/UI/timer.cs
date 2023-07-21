using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    public float timeValue = 90;
    public Text timerText;

    public gameManager gameManager;
    public GameObject enemyObject;

    private enemy enemy;
    public enemySpawn enemySpawn;

    private void Start()
    {
       
        //enemySpawn = GameObject.FindGameObjectWithTag("spawner").GetComponent<enemySpawn>();
    }



    // Update is called once per frame
    void Update()
    {
        //enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemy>();

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            gameManager.gameOver();
        }

        DisplayTime(timeValue);

    }


    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //if (seconds == 59)
        //{
        //    enemy.increaseDamage();
        //    enemySpawn.increaseSpawnRate();
        //}
        //if (seconds == 30)
        //{
        //    enemy.increaseDamage();
        //    enemySpawn.increaseSpawnRate();
        //}

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        
    }


}
