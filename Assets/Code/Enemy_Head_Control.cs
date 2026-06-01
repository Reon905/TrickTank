using UnityEngine;

public class Enemy_Head_Control : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrehab;
    public Transform firePoint;

    public float fireInterval = 1.0f;
    private float fireTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        //プレイヤーの方向を向く
        Vector3 direction = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        //発射タイマー
        fireTimer += Time.deltaTime;

        if(fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrehab, firePoint.position, firePoint.rotation);
    }

}
