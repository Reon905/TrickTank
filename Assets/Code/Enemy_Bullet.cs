using UnityEngine;

public class Enemy_Bullet:MonoBehaviour
{
    private Rigidbody rb;
    public int maxBounce = 2;
    private int bounceCount = 0;

    public int damage = 1;
    public Gun gun;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//弾についているRigidbodyを取得する

        Destroy(gameObject, 5f);//弾の残留時間
    }

    private void OnDestroy()
    {
        if(gun != null)
        {
            gun.ReturnBullet();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //プレイヤーに当たるとダメージを与える(自分もダメージ)
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        //弾同士で当たると相殺
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        //壁に当たったら反射
        if(!collision.gameObject.CompareTag("Wall"))
        {
            return;
        }

        //接触点情報
        ContactPoint contact = collision.contacts[0];

        //壁の法線
        Vector3 normal = contact.normal;//壁の表面の向き

        //XZ平面だけ使う(2D化)
        normal.y = 0;

        normal.Normalize();

        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0;

        //2D的な反射(XZ平面)　　　　　　　弾速維持を明確化
        Vector3 reflect = Vector3.Reflect(velocity, normal);

        reflect = reflect.normalized * velocity.magnitude;

        //少し押し戻す
        transform.position += normal * 0.05f;

        //速度反映
        rb.linearVelocity = new Vector3(reflect.x, rb.linearVelocity.y, reflect.z);

        bounceCount++;
    }

}
