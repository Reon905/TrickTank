using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMabager : MonoBehaviour
{
    public static int enemyCount = 0; //敵の数をカウントする
    private bool gameStarted = false;

    private void Start()
    {
        enemyCount = 0;        

    }

    private void Update()
    {
        Debug.Log("Update実行中");

        if(enemyCount  > 0) //敵が生成されてたらゲーム開始
        {
            Debug.Log("enemyCount > 0");
            gameStarted = true;
        }

        Debug.Log("enemyCount = " + enemyCount);
        Debug.Log("gameStarted = " + gameStarted);
        
        if(gameStarted && enemyCount <= 0)//敵を倒したらクリアシーンに移動
        {
            Debug.Log("");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
