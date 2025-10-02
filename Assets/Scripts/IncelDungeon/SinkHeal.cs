using UnityEngine;

public class SinkHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have healed you!");
        }
    }
}
