//Turret_control.cs

using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;   //バレットのプレハブ化
    public Transform firePoint;       //発射する場所?
    public float bulletSpeed = 80f;   //弾の速度



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

   
    }

    void Shoot()
    {
        // マウス位置
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Raycast結果
        RaycastHit hit;

        Vector3 targetPoint;

        // 何かに当たった場合
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            // 当たらなかった場合は遠くに飛ばす
            targetPoint = ray.GetPoint(100f);
        }

        // 発射方向
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        // 弾生成
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        // Rigidbody取得
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 速度を与える
        rb.velocity = direction * bulletSpeed;
    }
}