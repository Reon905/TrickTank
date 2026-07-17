using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Game終了");
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
    }

}
