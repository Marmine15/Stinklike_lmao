using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Transform playertarget;
    private ChunkController chunky;

    private void Start()
    {
        chunky = ChunkController.instance;
    }
    
    public void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DestoryPlayer()
    {
        playertarget = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(playertarget.gameObject);
        chunky.AddChunks();
    }
}
