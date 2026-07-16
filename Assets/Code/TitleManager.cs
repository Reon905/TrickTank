using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1 Scene");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2 Scene");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Stage3 Scene");
    }
}