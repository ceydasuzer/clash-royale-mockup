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
        if(opponentTurrets.Length > 0)
        {
            int randomTurret = Random.Range(0, opponentTurrets.Length);
            if(opponentTurrets[randomTurret] != null)
            {
                agent.SetDestination(opponentTurrets[randomTurret].transform.position);
            }
        }
 
    }
}
