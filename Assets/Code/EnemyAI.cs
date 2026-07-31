using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float patrolRadius = 15f;
    public float searchRange = 10f;
    public Transform player;
    public GameObject bulletPrefab;
    private NavMeshAgent agent;
    Vector3 patrolPoint;
    public enum EnemyState
    {
        Patrol,Attack
    }

    EnemyState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = EnemyState.Patrol;
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetRandomPoint();
    }

    void SetRandomPoint()
    {
        Vector3 randomPos =
            transform.position +
            Random.insideUnitSphere * patrolRadius;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPos,
                                   out hit,
                                   patrolRadius,
                                   NavMesh.AllAreas))
        {
            patrolPoint = hit.position;
            agent.SetDestination(patrolPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,player.position);

        if (distance < searchRange)
        {
           if(state == EnemyState.Attack)
            {
                agent.ResetPath();

                Vector3 lookPos =
                player.position - transform.position;

                lookPos.y = 0;

                transform.rotation =
                Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(lookPos),
                Time.deltaTime * 5);
            }
        }
        else
        {
            state = EnemyState.Patrol;
        }

        if (state == EnemyState.Patrol)
        {
            if (!agent.pathPending &&
               agent.remainingDistance < 0.5f)
            {
                SetRandomPoint();
            }
        }

    }
}
