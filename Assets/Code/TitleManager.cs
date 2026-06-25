using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private string raceSceneName = "Test scene";//シーン名を入れる

    private void Update()
    {
        //Enterキーでシーン切り替え
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Stage1 Scene");
        }
    }
}