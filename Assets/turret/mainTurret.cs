using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainTurret : MonoBehaviour
{
    [SerializeField] public int hitPoint = 2568;
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] public int damage = 54;
    [SerializeField] public float range = 7;

    public GameObject gameManager;
    private gameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (hitPoint <= 0)
        {
            gameObject.SetActive(false);
            print("main base fallen");

            manager.gameOver();
        }
    }
}
