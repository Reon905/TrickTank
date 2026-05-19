//Bullet_Reflection.cs

using UnityEngine;

public class Bullet_Reflection :MonoBehaviour
{
    private Rigidbody rb;

    public int maxBounce = 3; //最大反射回数
    private int bounceCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //反射回数制限
        if (bounceCount >= maxBounce)
        {
            Destroy(gameObject);
            return;
        }

        //接触点情報
        ContactPoint contact = collision.contacts[0];

        //壁の法線
        Vector3 normal = contact.normal;//壁の表面の向き

        //XZ平面だけ使う(2D化)
        normal.y = 0;

        normal.Normalize();

        Vector3 velocity = rb.velocity;
        velocity.y = 0;

        //2D的な反射(XZ平面)
        Vector3 reflect = Vector3.Reflect(velocity, normal);

        //少し押し戻す
        transform.position += normal * 0.05f;

        //速度反映
        rb.angularVelocity = new Vector3(reflect.x, rb.velocity.y, reflect.z);

        ////現在の進行方向
        //Vector3 direction = rb.velocity;

        ////反射方向計算
        //Vector3 reflectd = Vector3.Reflect(direction, normal);//(入射方向＋壁の法線 = 跳ね返る方向)

        ////少し壁から離す
        //transform.position += normal * 0.05f;

        ////velocity直接代入
        //rb.velocity = reflectd;

        bounceCount++;

        Debug.Log("Hit!");
    }
}
