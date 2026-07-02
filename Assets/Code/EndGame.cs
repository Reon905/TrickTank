using UnityEngine;

public class EndGame : MonoBehaviour
{
    //InspectorからExitPanelを登録
    public GameObject exitPanel;
    void Update()
    {
        //Escを押したら確認画面を表示
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
    }    
    //確認ではいを選んだ場合の処理
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }

    //いい絵を選んだ場合
    public void CancelQuit()
    {
        exitPanel.SetActive(false);
    }
}
