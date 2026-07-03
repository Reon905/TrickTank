using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_stage : MonoBehaviour
{
    public static int currentStage = 1;

    public void NextStage()
    {
        switch (GameMabager.currentStage)
        {
            case 1:
                SceneManager.LoadScene("Stage2 Scene");
                break;
            case 2:
                SceneManager.LoadScene("Stage3 Scene");
                break;
            default:
                SceneManager.LoadScene("Title Scene");
                break;
        }

    }

}
