using System;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Speed")]
    public float moveSpeed;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
    
    [Header("Range")]
    public float sightRange;
    public float chaseRange;
    public bool canChase;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;

        currentHealth = maxHealth;
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

    public void TakeDamage(int dameg)
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.chartreuse;  
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.aquamarine; 
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
