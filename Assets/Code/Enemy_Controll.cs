//Enemy_Control.cs
using UnityEngine;

public class Enemy_Control:MonoBehaviour
{
    private int hp = 3;
    private float rotateSeed= 3f;            //回転速度
    private float movespeed = 40;            //前、後 移動速度
    private CharacterController controller;  //コンポーネント保存
    private float changeDirectionTime = 2f;  //方向転換する間隔
    private float timer = 0f;
    private float targetRotate = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Debug.Log("エネミー実行中");
    }

    private void Update()
    {


        if(hp == 0)
        {
            Destroy(gameObject);
            Debug.Log("敵倒れた");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            hp--;

            Debug.Log("hp減少");
        }
    }

}
