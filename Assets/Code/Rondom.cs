using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rondom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Warp());
    }

    private IEnumerator Warp()
    {
        while (true)
        {
            // 10秒後ごとにワープ移動する。
            yield return new WaitForSeconds(10f);

            // ランダムな値を取得する。
            float posX = Random.Range(-120, 120);
            float posZ = Random.Range(-200, 200);

            transform.position = new Vector3(posX, 0, posZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
