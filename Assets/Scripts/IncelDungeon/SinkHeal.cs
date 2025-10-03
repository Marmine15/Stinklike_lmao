using UnityEngine;

public class SinkHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.currentHealth = player.maxHealth;
        }
    }
}
