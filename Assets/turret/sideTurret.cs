using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideTurret : MonoBehaviour
{

    [SerializeField] public int hitPoint = 1512;
    [SerializeField] public float attackSpeed = 0.8f;
    [SerializeField] public int damage = 54;
    [SerializeField] public float range = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (hitPoint < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
