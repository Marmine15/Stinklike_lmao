using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]

public class HealthBuff : PowerUpEffect
{
    public int amount;
    private int oldValue;

    public override void Apply(GameObject target)
    {
        var clone = target.GetComponent<PlayerController>();
        oldValue = clone.currentHealth;
        
        clone.currentHealth += amount;
    }
}
