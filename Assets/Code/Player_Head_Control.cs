//Player_Head_Control.cs

using UnityEngine;

public class Player_Head_Control : MonoBehaviour
{
    [Header("Rotetion")]
    [SerializeField] private float rotationOffsetY = 90f;


    private void Start()
    {
        //マウスカーソルを表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;//マウスを表示して自由に動かす
    }
    private void Update()
    {
        Rotate();//回転を先に実行

    }

    private void Rotate()
    {
        //マウスの位置を取得
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);//地面の平面
        float rayDistance;

        //レイと平面の交点を計算
        if (groundPlane.Raycast(cameraRay, out rayDistance))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayDistance);//交点を取得

            //プレイヤーの向きを計算
            Vector3 direction = pointToLook - transform.position;//プレイヤーの位置から交点までの方向
            direction.y = 0;//Y成分を0にして水平面にする


            //向きを補間してスムーズに回転
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);//向きを計算

                //Y回転軸オフセット
                rotation *= Quaternion.Euler(0, rotationOffsetY, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);//スムーズに回転

            }
        }
    }
}
