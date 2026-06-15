//Bullet_Reflection.cs

using UnityEngine;

public class Bullet_Reflection : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer bulletRenderer;//Rendererを使うための変数名

    public int maxBounce = 3; //最大反射回数
    public int damege = 1;
    private int bounceCount = 0;
    private float speed;//反射時の速度変数

    public Gun gun;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();//弾についているRigidbodyを取得する
        bulletRenderer = GetComponent<Renderer>();

        speed = rb.linearVelocity.magnitude;

        Destroy(gameObject, 5f);//弾の残留時間
    }

    private void OnDestroy()
    {
        if (gun != null)
        {
            gun.ReturnBullet();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //敵,プレイヤーに当たると消滅(敵,自分にもダメージ)
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            return;
        }

        //弾同士で当たると相殺
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Debug.Log("Ps:相殺");
            return;
        }



        //壁に当たったら反射
        if (!collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;//反射時の速度維持る

            Debug.Log("Ps:壁に当たった");
            return;
        }

        bounceCount++;
  

        //反射したときに弾の色を変える
        switch (bounceCount)
        {
            case 1:
                bulletRenderer.material.color = Color.yellow;
         
                Debug.Log("反射1回目");
                damege++;
                break;

            case 2:
                bulletRenderer.material.color = Color.red;
                Debug.Log("反射2回目");
                damege++;
                break;
        }

        if(bounceCount > maxBounce)
        {
            Destroy(gameObject);
            return;
            Debug.Log("最大反射回数到達");
        }

    }

}
