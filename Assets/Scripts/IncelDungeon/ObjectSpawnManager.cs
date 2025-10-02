using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnManager : MonoBehaviour
{
    public GameObject[] airEnemies;
    public GameObject[] groundEnemies;
    public Transform[] enemyAirSpawnPoints;
    public Transform[] enemyGroundSpawnPoints;

    private void Start()
    {
        
    }

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
        }
    }
}
