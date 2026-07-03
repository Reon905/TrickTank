using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMabager : MonoBehaviour
{
    public static int enemyCount = 0; //敵の数をカウントする
    public static int currentStage = 1;//現在のステージ番号

    private bool gameStarted = false;
    private bool isClear = false;

    private void Start()
    {
        enemyCount = 0;

    }

    private void Update()
    {
        Debug.Log("Update実行中");

        Debug.Log("enemyCount=" + enemyCount + "gameStarted " + gameStarted);

        if(enemyCount  > 0) //敵が生成されてたらゲーム開始
        {
            Debug.Log("enemyCount > 0");
            gameStarted = true;
        }
        
        if(gameStarted && enemyCount <= 0 && !isClear)//敵を倒したらクリアシーンに移動
        {
            isClear = true;

            Debug.Log("CLEAR");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
