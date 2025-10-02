using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreneController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Martin");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
