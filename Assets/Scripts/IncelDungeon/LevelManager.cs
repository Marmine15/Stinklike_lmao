using UnityEngine;
using System.Collections;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text levelText;
    public Animator animator;

    private GameObject _player;
    private ChunkController _chunky;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _chunky = ChunkController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = _chunky.HowManyChunks().ToString();
        StartCoroutine(VisibleLevel());
    }

    private IEnumerator VisibleLevel()
    {
        // the plan is that we play an idle animation for the text, then it fades away with another animation
        yield return new WaitForSeconds(0.8f);
        animator.Play("LevelNumberGone");
    }
}
