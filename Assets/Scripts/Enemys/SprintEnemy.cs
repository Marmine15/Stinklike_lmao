using System;
using System.Collections;
using UnityEngine;

public class SprintEnemy : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    [Header("Speed")]
    public float moveSpeed;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
    
    [Header("Range")]
    public float sightRange;
    public float chaseRange;
    public float attackRange;
    public bool canChase;
    
    [Header("Attacking")]
    [SerializeField] public float attackSpeed;
    public float attackIntrevalCounter;
    public float attackTime;
    public bool attacking;
    public BoxCollider2D sprintCollider;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        _animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (target == null) return;

        _moveDirection = Vector3.Normalize(target.position - transform.position);
        
        if (Vector2.Distance(target.position, transform.position) < sightRange)
        {
            canChase = true;
            _animator.Play("Weeb_Run");
        }
        else if (Vector2.Distance(target.position, transform.position) > chaseRange)
        {
            canChase = false;
            _animator.Play("Weeb_Idel");
        }
        
        transform.localScale = transform.position.x > target.position.x ? new Vector2(1, 1) : new Vector2(-1, 1);
        
        if (Vector2.Distance(target.position, transform.position) < attackRange)
        {
            if (attacking) return;
            if (attackIntrevalCounter < Time.time)
            {
                StartCoroutine(Attackig());
            }
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = canChase ? _moveDirection.x * moveSpeed : 0;
    }
    
    private IEnumerator Attackig()
    {
        Vector3 pdirection = Vector3.Cross(transform.position - target.position, Vector3.forward);
        
        attacking = true;
        _animator.Play("Weeb_Attack");
        sprintCollider.enabled = true;
        yield return new WaitForSeconds(attackTime);
        
        attackIntrevalCounter = Time.time;
        yield return new WaitForSeconds(attackTime);
        attacking = false;
        _animator.Play("Weeb_Idel");
        sprintCollider.enabled = false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;  
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blueViolet; 
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.cadetBlue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
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
        }
    }
}
