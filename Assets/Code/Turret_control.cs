//Turret_control.cs

using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;   //バレットのプレハブを入れておく変数
    public Transform firePoint;       //発射する場所
    public float bulletSpeed = 80f;   //弾の速度
    
    public int bullet_max = 5;        //最大弾数
    private int currentBulletCount = 0;        //現在の弾数


    private void Start()
    {
        currentBulletCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if( currentBulletCount <bullet_max )
            {
                Shoot();
            }
            else
            {
                
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

        //発射中の弾数を増やす
        currentBulletCount++;

        //BulletスクリプトにGunを渡す
        bullet.GetComponent<Bullet_Reflection>().gun = this;
    }

    //弾が消えたらBullet_Reflectionから呼ばれる
    public void ReturnBullet()
    {
        currentBulletCount--;
    }
}