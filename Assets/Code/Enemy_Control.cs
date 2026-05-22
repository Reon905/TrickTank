using UnityEngine;

public class Enemy_Control:MonoBehaviour
{
    private int hp = 3;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(hp == 0)
        {
            Destroy(gameObject);
            Debug.Log("ìGì|ÇÍÇΩ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            hp--;

            Debug.Log("hpå∏è≠");
        }
    }

}
