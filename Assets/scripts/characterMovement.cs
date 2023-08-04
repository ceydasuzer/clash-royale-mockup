using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterMovement : MonoBehaviour
{

    private gameManager gameManager;
    public GameObject[] opponentTurrets;

    public NavMeshAgent agent;

    public float health;
    [SerializeField] private float range;

    [SerializeField] public int damage;


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
                Debug.Log("walking normal");


            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemyTurret"))
        {
            if(collision.gameObject.name == "main_opponent")
            {
                collision.gameObject.GetComponent<mainTurret>().hitPoint -= damage;
                Destroy(gameObject, 3f);
            }
            if(collision.gameObject.name == "side_opponent")
            {
                collision.gameObject.GetComponent<sideTurret>().hitPoint -= damage;
                Destroy(gameObject, 3f);
            }
            
        }

    }

    //public void TakeDamage(float damageAmount)
    //{
    //    health -= damageAmount;
    //    if(health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
