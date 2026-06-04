using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameObject Enemy;
    EnemyScript encs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        encs = Enemy.GetComponent<EnemyScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            encs.tuiseki();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            encs.haikai();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
