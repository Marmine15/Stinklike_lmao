using System.Collections;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Powerups/SpeedBuff")]

public class SpeedBuff : PowerUpEffect
{
    public float killTimer = 5f;
    public float amount;

    private float oldValue;
    
    public override void Apply(GameObject target)
    {
        var clone = target.GetComponent<PlayerController>();
        oldValue = clone.moveSpeed;
        
        clone.moveSpeed += amount;
        clone.StartCoroutine(Depower(clone));
    }

    private IEnumerator Depower(PlayerController target)
    {
        yield return new WaitForSeconds(killTimer);
        target.moveSpeed = oldValue;
    }
}
