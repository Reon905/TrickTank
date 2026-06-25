using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMabager : MonoBehaviour
{
    public static int enemyCount = 0;
    private bool gameStarted = false;

    private void Update()
    {
        if(enemyCount <=0)
        {
            gameStarted = true;


        }

        if(gameStarted && enemyCount <= 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
