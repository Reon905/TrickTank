//EnemyRunAway.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunAway : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;

    public float runDistance = 10f;
    public float detectDistance = 8f;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        //プレイヤーが近いと逃げる
        if(distance < detectDistance)
        {
            RunAway();
        }
    }

    void RunAway()
    {
        //プレイヤーから敵への方向
        Vector3 dir = (transform.position - player.position).normalized;

        //逃げる地点
        Vector3 targetPos = transform.position + dir * runDistance;

        //NavMeshの上の位置を探す
        NavMeshHit hit;

        if (NavMesh.SamplePosition(targetPos, out hit, runDistance, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
