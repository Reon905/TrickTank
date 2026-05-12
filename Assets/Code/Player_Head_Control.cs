//Player_Head_Control.cs

using UnityEngine;

public class Player_Head_Control : MonoBehaviour
{
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
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);//スムーズに回転
            }
        }
    }
}

/*マウス座標の取得の仕方*/
