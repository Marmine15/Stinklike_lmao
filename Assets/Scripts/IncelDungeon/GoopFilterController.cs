using UnityEngine;

public class GoopFilterController : MonoBehaviour
{
    public GameObject goopFilterMinor;
    private int _levelDifficulty;

    private void Start()
    {
        _levelDifficulty = ChunkController.ChunkAmount;
        if (_levelDifficulty >= 10)
        {
            goopFilterMinor.SetActive(true);
        }
    }
}
