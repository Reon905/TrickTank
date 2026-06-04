//Turret_control.cs

using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;   //バレットのプレハブを入れておく変数
    public Transform firePoint;       //発射する場所
    public float bulletSpeed = 80f;   //弾の速度
    public int bullet_max = 5;        //弾上限

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(bullet_max == 5)
            {
                Shoot();

            }
 


        }
   
    }

    void Shoot()
    {
        //発射方向(前方向)
        Vector3 direction = firePoint.forward;

        //弾生成
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        //Rigidbody取得
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        //前方向へ速度を与える
        rb.linearVelocity = direction * bulletSpeed;

    }
}