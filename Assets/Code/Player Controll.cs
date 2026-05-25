//Player Controll.cs

using UnityEngine;

public class PlayerControll: MonoBehaviour
{
    public int Hp = 2;
    public  float speed = 40f;               //前進・後退する速さ
    private float rotateSpeed = 0.3f;        //回転する速さ
    private CharacterController controller;  //コンポーネントを保存する変数です

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
        
        Debug.Log("プレイヤー実行中");
    }

    private void Update()
    {
        
        //回転処理
        transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed,0); //GetAxis("Horizontal")は左右入力

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float currentSpeed = speed * Input.GetAxis("Vertical");

        controller.SimpleMove(forward *  currentSpeed);

        //マウスの座標取得(テスト)
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("x:" + mousePos.x + "    y:" + mousePos.y);
        }

        if(Hp == 0)
        {
            Destroy(gameObject);
            Debug.Log("ヤ ラ レ チ ャ ッ タ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hp--;

            Debug.Log("ダメージを受けた!!");
        }

    }

};
