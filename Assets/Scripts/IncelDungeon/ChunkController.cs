using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ChunkController : MonoBehaviour
{
    public GameObject[] chunks;
    public GameObject startChunk;
    public GameObject endChunk;
    public List<Vector3> spawnPoint;
    
    public static int ChunkAmount;
    
    private float SpawnOffset = 10;
    private float nextSpawnPosition;
    
    

    private void Awake()
    {
        if (ChunkAmount < 3)
        {
            ChunkAmount = 3;
        }
        
        for (int i = 0; i < ChunkAmount; i++)
        {
            if (i == 0)
            {
                spawnPoint.Add(new Vector3(0,0,0));
                nextSpawnPosition  += SpawnOffset;
            }
            else
            {
                spawnPoint.Add(new Vector3(nextSpawnPosition,0,0));
                nextSpawnPosition += SpawnOffset;
            }
        }
    }

    private void Start()
    {
        foreach (Vector3 point in spawnPoint)
        {
            if (point == spawnPoint[0])
            {
                Instantiate(startChunk, point, Quaternion.identity);
            }
            else if (point == spawnPoint[spawnPoint.Count])
            {
                Instantiate(endChunk, point, Quaternion.identity);
            }
            else
            {
                Instantiate(chunks[Random.Range(0, chunks.Length)], point, Quaternion.identity);
            }
            
        }
    }

    private void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            ChunkAmount++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}