//Enemy_Bullet
using UnityEngine;

public class Enemy_Bullet:MonoBehaviour
{
    private Rigidbody rb;
    public int maxBounce = 2;
    private int bounceCount = 0;
    private float speed;

    public int damage = 1;
    public Enemy_TurretControl etc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//弾についているRigidbodyを取得する

        speed = rb.linearVelocity.magnitude;

        Destroy(gameObject, 5f);//弾の残留時間
    }

    private void OnDestroy()
    {
        if(etc != null)
        {
            etc.ReturnBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //プレイヤーに当たるとダメージを与える(自分もダメージ)
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //プレイヤーが消滅すると打つのをやめる
           if(gameObject.CompareTag("Player"))

            return;
        }

        //弾同士で当たると相殺
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Debug.Log("Es:相殺");
            return;
        }

        //壁に当たったら反射
        if(!collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
            Debug.Log("Es:壁に当たった");
            return;
        }

        bounceCount++;
    }

}
