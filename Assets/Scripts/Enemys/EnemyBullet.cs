using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("DiscordEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
