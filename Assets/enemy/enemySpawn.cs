using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    [SerializeField] public int spawnPointRight;
    [SerializeField] public int spawnPointLeft;

    public float spawnRate = 3;
    private float timer = 0;

    private void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }else
        {
            spawnEnemy();
            timer = 0;
        }
    }

    public void increaseSpawnRate()
    {
        spawnRate += 3;
    }

    public void spawnEnemy()
    {

        Instantiate(enemy, new Vector3(Random.Range(spawnPointLeft, spawnPointRight), enemyPos.position.y, enemyPos.position.z),transform.rotation);
        
    }
}
