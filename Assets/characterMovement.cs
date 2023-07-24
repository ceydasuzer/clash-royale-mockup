using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterMovement : MonoBehaviour
{

    private gameManager gameManager;
    public GameObject[] opponentTurrets;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        opponentTurrets = GameObject.FindGameObjectsWithTag("enemyTurret");
        gameManager = gameObject.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
 
        for (int i = 0; i <= 3; i++)
        {
            int randomTurret = Random.Range(0, 2);
            //     Debug.Log(randomTurret);
            //     agent.SetDestination(turrets[randomTurret].transform.position);

            if (opponentTurrets[0] != null)
            {
                Debug.Log("turret 0 is not null");
                agent.SetDestination(opponentTurrets[0].transform.position);
                if (opponentTurrets[0] == null)
                {
                    agent.SetDestination(opponentTurrets[1].transform.position);
                }
            }
            else if (opponentTurrets[1] != null)
            {
                Debug.Log("turret 0 is not null");
                agent.SetDestination(opponentTurrets[1].transform.position);
                if (opponentTurrets[1] == null)
                {
                    agent.SetDestination(opponentTurrets[0].transform.position);
                }
            }
            else if (opponentTurrets[0] == null & opponentTurrets[1] == null)
            {
                Debug.Log("turret 0-1 is null");
                agent.SetDestination(opponentTurrets[2].transform.position);
            }
            else if (opponentTurrets[2] == null)
            {
                Debug.Log("main is null");
            }

        }
    }
}
