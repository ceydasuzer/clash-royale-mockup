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

    sideTurret sideTurret;
    mainTurret mainTurret;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        turrets = GameObject.FindGameObjectsWithTag("turret");

    }

    // Update is called once per frame
    void Update()
    {
       int randomTurret = Random.Range(0, 2);

        for (int i =0; i < 3; i++)
        {
            agent.SetDestination(turrets[randomTurret].transform.position);
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
        }
        
    }
}
