using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float moveSpeed;

    public Transform target;
    public float sightRange;
    public float chaseRange;
    public bool canChase;

    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target == null) return;

        _moveDirection = Vector3.Normalize(target.position - transform.position);
        
        if (Vector2.Distance(target.position, transform.position) < sightRange)
        {
            canChase = true;
        }
        else if (Vector2.Distance(target.position, transform.position) > chaseRange)
        {
            canChase = false;
        }
        
        transform.localScale = transform.position.x > target.position.x ? new Vector2(1, 1) : new Vector2(-1, 1);
           
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = canChase ? _moveDirection.x * moveSpeed : 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.chartreuse;  
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.aquamarine; 
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    
}
