using UnityEngine;

public class Enemy_Bullet:MonoBehaviour
{
    private Rigidbody rb;
    public int maxBounce = 2;
    private int bounceCount = 0;
    private float speed;

    public int damage = 1;
    public Gun gun;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//’e‚É‚Â‚¢‚Ä‚¢‚éRigidbody‚ğæ“¾‚·‚é

        speed = rb.linearVelocity.magnitude;

        Destroy(gameObject, 5f);//’e‚Ìc—¯ŠÔ
    }

    private void OnDestroy()
    {
        if(gun != null)
        {
            gun.ReturnBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ƒvƒŒƒCƒ„[‚É“–‚½‚é‚Æƒ_ƒ[ƒW‚ğ—^‚¦‚é(©•ª‚àƒ_ƒ[ƒW)
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        //’e“¯m‚Å“–‚½‚é‚Æ‘ŠE
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Debug.Log("Es:‘ŠE");
            return;
        }

        //•Ç‚É“–‚½‚Á‚½‚ç”½Ë
        if(!collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
            Debug.Log("Es:•Ç‚É“–‚½‚Á‚½");
            return;
        }

        bounceCount++;
    }

}
