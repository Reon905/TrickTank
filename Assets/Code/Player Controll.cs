//Player Controll

using UnityEngine;

public class PlayerControll: MonoBehaviour
{
    public  float speed = 20f;               //前進・後退する速さ
    private float rotateSpeed = 1.0f;        //回転する速さ
    private CharacterController controller;  //コンポーネントを保存する変数です

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //回転処理
        transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed,0); //GetAxis("Horizontal")は左右入力

        Vector3 forwad = transform.TransformDirection(Vector3.forward);

        float currentSpeed = speed * Input.GetAxis("Vertical");

        controller.SimpleMove(forwad *  currentSpeed);
    }
};
