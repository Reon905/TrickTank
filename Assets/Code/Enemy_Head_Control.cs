using UnityEngine;

public class Enemy_Head_Control : MonoBehaviour
{
    public Transform player;
    public float turretRotateSpeed = 60f;//–C“ƒ‰ñ“]‘¬“x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        //ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ğŒü‚­
        Vector3 direction = player.position - transform.position;

        //–C“ƒ‚Í…•½‰ñ“]‚ğ‚·‚é
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turretRotateSpeed * Time.deltaTime);
        }
    }

}
