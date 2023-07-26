using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    private List<GameObject> turrets = new List<GameObject>();
    private GameObject currentTarget;

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
        gameManager = gameObject.GetComponent<gameManager>();
        GameObject[] turretObjects = GameObject.FindGameObjectsWithTag("turret");
        foreach( GameObject turret in turretObjects)
        {
            turrets.Add(turret);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(turrets.Count > 0)
        {
            int randomTurret = Random.Range(0, turrets.Count-1);
            if(turrets[randomTurret].activeSelf)
            {
                agent.SetDestination(turrets[randomTurret].transform.position);
            }
        }
        else
        {
            Debug.Log("finding new target");
            FindNewTarget();
        }
        

    }

    private void FindNewTarget()
    {
        List<GameObject> activeTurrets = new List<GameObject>();
        foreach (GameObject turret in turrets)
        {
            if(turret != null && turret.activeSelf)
            {
                activeTurrets.Add(turret);
            }
        }

        if (activeTurrets.Count > 0)
        {
            int randomTurretIndex = Random.Range(0, activeTurrets.Count);
            currentTarget = activeTurrets[randomTurretIndex];
            agent.SetDestination(currentTarget.transform.position);
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
