using UnityEngine;

public class Enemy_Head_Control : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrehab;
    public Transform firePoint;

    public float fireInterval = 1.0f;
    public float turretRotateSpeed = 60f;//–C“ƒ‰ñ“]‘¬“x

    private float fireTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        //ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ðŒü‚­
        Vector3 direction = player.position - transform.position;

        //–C“ƒ‚Í…•½‰ñ“]‚ð‚·‚é
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turretRotateSpeed * Time.deltaTime);
        }

        //”­ŽËƒ^ƒCƒ}[
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
