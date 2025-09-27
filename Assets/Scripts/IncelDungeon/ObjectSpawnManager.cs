using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;

    private void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], point.position, Quaternion.identity);
        }
    }
}
