//Bullet_Reflection.cs

using UnityEngine;

public class Bullet_Reflection :MonoBehaviour
{
    private Rigidbody rb;

    public int maxBounce = 2; //最大反射回数
    private int bounceCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//弾についているRigidbodyを取得する

        Destroy(gameObject, 5f);//弾の残留時間
    }

    void OnCollisionEnter(Collision collision)
    {

        //敵,プレイヤーに当たると消滅(敵,自分にもダメージ)
        if(collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            return;
        }

        //壁以外
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

        Debug.Log("Hit!");
    }
}
