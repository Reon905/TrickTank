//Enemy_TurretControl
using UnityEngine;

public class Enemy_TurretControl : MonoBehaviour
{
    public GameObject bulletPurefab;    //エネミーの弾プレハブを入れる
    public Transform firePoint;         //発射する場所
    public float bulletSpeed = 80;      //弾の速度

    public int bullet_max = 5;          //最大弾数
    private int currentBulletCount = 0; //現在の弾数

    private float timer;

    private void Start()
    {
        currentBulletCount = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1f && currentBulletCount < bullet_max)
        {
            Shoot();
            timer = 0f;
        }

    }

    void Shoot()
    {
        //発射方向(前方向)
        Vector3 direction = firePoint.forward;

        //弾生成
        GameObject bullet = Instantiate(
            bulletPurefab,
            firePoint.position,
            firePoint.rotation
       );

        //Rigidbody取得
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //前方向へ速度を与える
        rb.linearVelocity = direction * bulletSpeed;

        //発射中の弾数を増やす
        currentBulletCount++;

        //BulletスクリプトにEnemy_TulletControl(etc)を渡す
        bullet.GetComponent<Enemy_Bullet>().etc = this;
    }

    //弾が消えたらBullet_Reflectionから呼ばれる
    public void ReturnBullet()
    {
        currentBulletCount--;
    }
}
