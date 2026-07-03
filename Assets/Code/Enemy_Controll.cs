//Enemy_Control.cs
using UnityEngine;

public class Enemy_Control:MonoBehaviour
{
    private int hp = 3;
    private float rotateSeed= 3f;            //‰ñ“]‘¬“x
    private float movespeed = 40;            //‘OAŒã ˆÚ“®‘¬“x
    private CharacterController controller;  //ƒRƒ“ƒ|[ƒlƒ“ƒg•Û‘¶
    private float changeDirectionTime = 2f;  //•ûŒü“]Š·‚·‚éŠÔŠu
    private float timer = 0f;
    private float targetRotate = 0f;
    private bool isDead = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        GameManager.enemyCount++;

        Debug.Log("“G¶¬ “G”:" + GameManager.enemyCount);
    }

    private void Update()
    {

        if(hp <= 0 && !isDead)
        {
            isDead = true;

            GameManager.enemyCount--;

            if(GameManager.enemyCount < 0)
            {
                GameManager.enemyCount = 0;
            }

            Debug.Log("“G“|‚ê‚½ “G”:" + GameManager.enemyCount);

            Destroy(gameObject);
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Bullet_Reflection bullet = collision.gameObject.GetComponent<Bullet_Reflection>();

            if(bullet != null)
            {
                hp -= bullet.damege;

                Debug.Log("”í’e" + hp);

                Destroy(collision.gameObject);
            }
        }
    }

}
