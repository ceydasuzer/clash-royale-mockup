using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    public GameObject[] turrets;

    public int damage;
    public int enemy_hp;
    public int maxHealth = 200;
    public int currentHealth;


    public enemySpawn enemySpawn;

    private gameManager gameManager;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        turrets = GameObject.FindGameObjectsWithTag("turret");
        gameManager = gameObject.GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(turrets.Length > 0)
        {
            int randomTurret = Random.Range(0, turrets.Length-1);
            if(turrets[randomTurret] != null)
            {
                agent.SetDestination(turrets[randomTurret].transform.position);
            }
        }
        else
        {
            agent.isStopped = true;
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "side")
        {

            collision.gameObject.GetComponent<sideTurret>().hitPoint -= damage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "main")
        {
            collision.gameObject.GetComponent<mainTurret>().hitPoint -= damage;
            Destroy(gameObject);
        }
        
    }
}
