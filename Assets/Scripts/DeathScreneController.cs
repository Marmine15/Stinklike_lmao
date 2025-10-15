using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreneController : MonoBehaviour
{
    ChunkController chunkController;
    public TMP_Text finalScore;

    private void Start()
    {
        chunkController = ChunkController.instance;
        finalScore.text = "Final Score: " + chunkController.HowManyChunks();
    }
    
    public void Restart()
    {
        chunkController.ResetChunks();
        SceneManager.LoadScene("Martin");
    }

    public void Quit()
    {
        chunkController.ResetChunks();
        SceneManager.LoadScene("MainMenu");
    }
}
