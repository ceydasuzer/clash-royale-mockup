using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    public float timeValue = 90;
    public Text timerText;

    public gameManager gameManager;
    [SerializeField]public GameObject enemyObject;

    [SerializeField]public GameObject enemySpawner;
    private enemySpawn spawner;

    private enemy enemy;

    public int damage;

    private void Start()
    {
        
        spawner = enemySpawner.GetComponent<enemySpawn>();
        enemy = enemyObject.GetComponent<enemy>(); 
    }

  

    // Update is called once per frame
    void Update()
    {
        //damage = enemy.damage;
        
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            if (timeValue <= (Convert.ToSingle(60.00000)))
            {
                spawner.spawnRate = 3f;
                enemy.damage = 300;
            }
            if (timeValue <= Convert.ToSingle(30.00000))
            {
                spawner.spawnRate = 2;
                enemy.damage = 350;
            }
        }
        else
        {
            timeValue = 0;
            enemy.damage = 200;
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




        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        
    }


}
