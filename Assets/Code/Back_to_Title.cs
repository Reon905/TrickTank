using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_to_Title : MonoBehaviour
{
    public void BackTitle()
    {
        Debug.Log("BackTitle‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Scene");
    }
   
}
