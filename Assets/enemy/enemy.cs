using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    //public Transform sideTurret_1;
    //public Transform sideTurret_2;
    //public Transform mainTurret;
    public GameObject[] turrets;

    public int damage;
    public int enemy_hp;

    //sideTurret sideTurret;
    //mainTurret mainTurret;

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

        for (int i = 0; i <= 3; i++)
        {

            int randomTurret = Random.Range(0, 2);

                Debug.Log(randomTurret);
                agent.SetDestination(turrets[randomTurret].transform.position);

            if (turrets[0] != null)
            {
                Debug.Log("turret 0 is not null");
                agent.SetDestination(turrets[0].transform.position);
                if (turrets[0] == null)
                {
                    agent.nextPosition = turrets[1].transform.position;
                }
            }
            else if (turrets[1] != null)
            {
                Debug.Log("turret 0 is not null");
                agent.SetDestination(turrets[1].transform.position);
            }
            else if( turrets[0] == null & turrets[1] == null)
            {
                Debug.Log("turret 0-1 is null");
                agent.SetDestination(turrets[2].transform.position);
            }
            else if (turrets[2] == null) {
                Debug.Log("main is null");
                agent.speed = 0;
                enemySpawn.spawnRate = 0;
            }

        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "side")
        {
            print("enemy in side");
            collision.gameObject.GetComponent<sideTurret>().hitPoint -= damage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "main")
        {
            print("enemy in main");
            collision.gameObject.GetComponent<mainTurret>().hitPoint -= damage;
            Destroy(gameObject);
        }
        
    }
}
