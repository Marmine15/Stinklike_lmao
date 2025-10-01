using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bullet : MonoBehaviour
{
    public float killTimer = 10f; // initial time in seconds
    public float killTimerReset;
    public bool isAlive = true;

    //private ScoreManager score;

    private void Start()
    {
        isAlive = true;
        killTimerReset = killTimer;
        
        //score = ScoreManager.instance;
    }
    
    private void Update()
    {
        if (isAlive)
        {
            if (killTimer > 0)
            {
                killTimer -= Time.deltaTime;
            }
            else
            {
                killTimer = 0f;
                gameObject.SetActive(false);
                isAlive = false;
            }
        }
        else
        {
            isAlive = true;
            killTimer = killTimerReset;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground"))
        {
            killTimer = killTimerReset;
            gameObject.SetActive(false);
        }
    }
}
