//Player Controll.cs

using UnityEngine;

public class PlayerControll: MonoBehaviour
{
    public  float speed = 40f;               //前進・後退する速さ
    private float rotateSpeed = 0.3f;        //回転する速さ
    private CharacterController controller;  //コンポーネントを保存する変数です

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
        
        Debug.Log("実行中");
    }

    private void Update()
    {
        
        //回転処理
        transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed,0); //GetAxis("Horizontal")は左右入力

        Vector3 forwad = transform.TransformDirection(Vector3.forward);

        float currentSpeed = speed * Input.GetAxis("Vertical");

        controller.SimpleMove(forwad *  currentSpeed);


        //マウスの座標取得(テスト)
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("x:" + mousePos.x + "    y:" + mousePos.y);
        }

    }

};
