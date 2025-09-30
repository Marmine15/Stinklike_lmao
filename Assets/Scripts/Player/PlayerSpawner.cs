using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform SpawnPoint;
    
    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);
        
    }
    
    
    
    
    
}
