using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Transform Target;
    public Transform random;
    NavMeshAgent agent;
    bool sensor;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sensor == false)
        {
            agent.destination = random.transform.position;
        }
        else
        {
            agent.destination = Target.transform.position;
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
}









////EnemyRunAway.cs
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyRunAway : MonoBehaviour
//{
//    private NavMeshAgent agent;
//    private Transform playerTarget;

//    void Start()
//    {
//        // NavMeshAgentコンポーネントを取得
//        agent = GetComponent<NavMeshAgent>();

//        // プレイヤーオブジェクトを探してターゲットに設定
//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//        {
//            playerTarget = player.transform;
//        }
//    }

//    void Update()
//    {
//        // ターゲット（プレイヤー）が存在すれば、その位置を目的地に設定し続ける
//        if (playerTarget != null)
//        {
//            agent.SetDestination(playerTarget.position);
//        }

//        // Animatorに速度を渡して歩行アニメーションを再生させる（オプション）
//        // Animator animator = GetComponent<Animator>();
//        // if (animator != null)
//        // {
//        //     animator.SetFloat("Speed", agent.velocity.magnitude);
//        // }
//    }
//}


//    //// Start is called once before the first execution of Update after the MonoBehaviour is created
//    //public Transform player;

//    //public float runDistance = 10f;
//    //public float detectDistance = 8f;

//    //private NavMeshAgent agent;
//    //void Start()
//    //{
//    //    agent = GetComponent<NavMeshAgent>();
//    //}

//    //// Update is called once per frame
//    //void Update()
//    //{
//    //    float distance = Vector3.Distance(transform.position, player.position);

//    //    //プレイヤーが近いと逃げる
//    //    if (distance < detectDistance)
//    //    {
//    //        RunAway();
//    //    }
//    //}

//    //void RunAway()
//    //{
//    //    //プレイヤーから敵への方向
//    //    Vector3 dir = (transform.position - player.position).normalized;

//    //    //逃げる地点
//    //    Vector3 targetPos = transform.position + dir * runDistance;

//    //    //NavMeshの上の位置を探す
//    //    NavMeshHit hit;

//    //    if (NavMesh.SamplePosition(targetPos, out hit, runDistance, NavMesh.AllAreas))
//    //    {
//    //        agent.SetDestination(hit.position);
//    //    }