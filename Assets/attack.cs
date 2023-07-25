using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    [SerializeField] private float range = 2f;
    [SerializeField] private float damage;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        DetectOpponent();
    }

    private void DetectOpponent()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("enemy"))
            {
                attack opponentInRange = collider.GetComponent<attack>();
                if(opponentInRange != null)
                {
                    Debug.Log("opponent in range");
                    attackOpponent(opponentInRange);

                }
            }
        }
    }


    private void attackOpponent(attack opponentInRange)
    {
        if(agent != null)
        {
            agent.SetDestination(opponentInRange.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, range);
    }
}


