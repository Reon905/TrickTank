using UnityEngine;

public class TitleManager2 : MonoBehaviour
{

    public GameObject TitleCanvas;
    public GameObject StageSelectCanvas;

    //
    void Start()
    {
        TitleCanvas.SetActive(true);
        StageSelectCanvas.SetActive(false);
    }

    //スタートボタン押したとき
    public void OpenStageSelect()
    {
        Debug.Log("Stageボタンが押されました");

        TitleCanvas.SetActive(false);
        StageSelectCanvas.SetActive(true);
    }

    //ステージセレクトから戻るボタンを押したとき
    public void BackToTitle()
    {
        TitleCanvas.SetActive(true);
        StageSelectCanvas.SetActive(false);
    }

}
