using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnManager : MonoBehaviour
{
    [Header("Enemy Related Stuffs")]
    public GameObject[] airEnemies;
    public GameObject[] groundEnemies;
    public Transform[] enemyAirSpawnPoints;
    public Transform[] enemyGroundSpawnPoints;
    
    [Header("Object Related Stuffs")]
    public GameObject[] powerUps;
    public Transform[] powerUpSpawnPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform point in enemyAirSpawnPoints)
            {
                Instantiate(airEnemies[Random.Range(0, airEnemies.Length)], point.position, Quaternion.identity);
            }

            foreach (Transform point in enemyGroundSpawnPoints)
            {
                Instantiate(groundEnemies[Random.Range(0, groundEnemies.Length)], point.position, Quaternion.identity);
            }

            foreach (Transform point in powerUpSpawnPoints)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Length)], point.position, Quaternion.identity);
            }
            
            gameObject.SetActive(false);
        }
    }
}
