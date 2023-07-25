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
            agent.SetDestination(opponentTurrets[randomTurret].transform.position);



        }
    }
}
