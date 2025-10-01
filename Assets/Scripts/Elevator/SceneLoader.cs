using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Transform playertarget;
    
    public void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DestoryPlayer()
    {
        playertarget = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(playertarget.gameObject);
    }
}
