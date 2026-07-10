//EnemyRunAway.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float atttackDistance = 8f;
    public float attackInterval = 1.5f;

    public Transform Target;
    public Transform random;
    NavMeshAgent agent;
    bool sensor;
    public float speed;

    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sensor)
        {
            agent.destination = random.position;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, Target.position);

            if(distance > atttackDistance)
            {
                //ƒvƒŒƒCƒ„[‚ð’Ç‚¢‚©‚¯‚é
                agent.destination = Target.position;
            }
            else
            {
                //UŒ‚‚·‚é‚½‚ß’âŽ~
                agent.ResetPath();

                Attack();
            }
        }

    }

    public void tuiseki()
    {
        sensor = true;
    }

    public void haikai()
    {
        sensor = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
   void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            attackTimer = 0;

            ShootPlayer();
        }
    }

    void ShootPlayer()
    {
        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        Vector3 dir = (Target.position - firePoint.position).normalized;

        rb.linearVelocity = dir * 10f;
    }
}

