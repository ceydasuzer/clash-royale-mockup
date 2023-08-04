using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private int damage;


    private NavMeshAgent agent;
    private float lastAttackTime;

    public GameObject healthSystem;


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
       float cooldown = .7f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("enemy"))
            {
                    attack enemyInRange = collider.GetComponent<attack>();
                    if (enemyInRange != null)
                    {

                        if (enemyInRange)
                        {
                            // Debug.Log(collider.gameObject);
                             agent.SetDestination(enemyInRange.transform.position);
                            enemy enemy = collider.GetComponent<enemy>();
                            if (Time.time - lastAttackTime >= cooldown)
                            {
                                enemy.enemy_hp -= damage;
                           // Debug.Log("enemy is dying");
                        }
                            lastAttackTime = Time.time;
                            
                        }

                }
            }

            else if ((gameObject.tag == "enemy") && (collider.CompareTag("dragon") || collider.CompareTag("knight") || collider.CompareTag("healer") || collider.CompareTag("witch")))
            {
                characterMovement playerInRange = collider.GetComponent<characterMovement>();
                if (playerInRange != null)
                {
                    Debug.Log("player in range");
                    if (playerInRange)
                    {
                        //Debug.Log(collider.gameObject);
                        agent.SetDestination(playerInRange.transform.position);
                        if (Time.time - lastAttackTime >= cooldown)
                        {
                            healthSystem health = collider.GetComponent<healthSystem>();
                            health.currentHealth -= damage;
                            Debug.Log("player is dying");
                        }
                    }

                }
            }

        }
    }

    //private void AttackPlayer(characterMovement playerInRange)
    //{
    //    if(Time.time - lastAttackTime >= cooldown)
    //    {
    //        if (agent != null)
    //        {
    //            agent.SetDestination(playerInRange.transform.position);
    //            Debug.Log("enemy attacking");
                

    //        }

    //        lastAttackTime = Time.time;
    //    }


    //}
    //private void attackOpponent(attack opponentInRange)
    //{
    //    if (Time.time - lastAttackTime >= cooldown)
    //    {
    //        if (agent != null)
    //        {
    //            Debug.Log("player attacking");
    //            agent.SetDestination(opponentInRange.transform.position);
    //            Debug.Log("enemy is dying");
    //        }
    //        lastAttackTime = Time.time;
    //    }

    //}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, range);
    }
}


