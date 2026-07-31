using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=
    transform.forward *
    speed *
    Time.deltaTime;
    }

    public void Damage(int damage)
    {
        int Hp = 0;
        Hp -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControll>().Damage(1);
            Debug.Log("Player Hit!");
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }

}
