//Next_stage.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_stage : MonoBehaviour
{
    public static int currentStage;

    public void NextStage()
    {
    GameManager.currentStage++;
           Debug.Log("ƒ{ƒ^ƒ“‰Ÿ‚µ‚½");
    if (GameManager.currentStage <= 3)
    { 
        SceneManager.LoadScene(
            "Stage" + GameManager.currentStage);

    }
    else
    {
        SceneManager.LoadScene("Title");

    }
    }

}
