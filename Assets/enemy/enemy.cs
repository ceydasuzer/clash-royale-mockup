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

        for (int i = 0; i < 3; i++)
        {

            int randomTurret = Random.Range(0, 2);
            if (turrets[randomTurret] != null)
            {
                agent.SetDestination(turrets[randomTurret].transform.position);

            }else if (turrets[0] != null)
            {
                agent.nextPosition = turrets[0].transform.position;
            }
            else if (turrets[1] != null)
            {
                agent.nextPosition = turrets[1].transform.position;
            }
            else if( turrets[0] == null & turrets[1] == null)
            {
                agent.nextPosition = turrets[2].transform.position;
            }
            else if (turrets[2] == null) {
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
