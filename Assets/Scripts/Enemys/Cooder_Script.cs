using System.Collections;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [Header("Targets")]
    public Transform target;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Ranges")]
    [SerializeField]public float attackRange;

    [Header("Attacking")]
    [SerializeField] public float attackSpeed;
    public float attackIntrevalCounter;
    public float shootTime;
    public bool shooting;
    
    [Header("BulletSettings")]
    [SerializeField]private GameObject bullet;
    [SerializeField]private float bulletCooldown;
    public Transform bulletSpawn;
    private float _bulletTimer;
    public float bulletSpeed;
    public float bulletLifetime;

    [Header("Death")] public GameObject cleanCoder;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            _animator.Play("CoderClean");
        }
        else
        {
            if (target != null)
            {
                if (Vector2.Distance(target.position, transform.position) < attackRange)
                {
                    if (shooting) return;
                    if (attackIntrevalCounter < Time.time)
                    {
                        StartCoroutine(Shooting());
                    }
                }
        
                if (target.position.x - transform.position.x > 0)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.linearVelocityX > 0)
        {
            _animator.Play("Coder_Move");
        }
    }

    private IEnumerator Shooting()
    {
        shooting = true;
        _animator.Play("Coder_Attack");
        yield return new WaitForSeconds(shootTime);
        Vector3 pdirection = target.position - transform.position;
        var targetPos = target.position;
        _bulletTimer = bulletCooldown;
        var projectileClone =
            Instantiate(bullet, bulletSpawn.position,
                Quaternion.identity);
        projectileClone.TryGetComponent(out Rigidbody2D rb2D);
        
        rb2D.linearVelocity = pdirection.normalized * (bulletSpeed);
        Destroy(projectileClone, bulletLifetime);
        attackIntrevalCounter = Time.time;
        yield return new WaitForSeconds(shootTime);
        shooting = false;
        _animator.Play("Coder_Idle");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;
        }
    }

    public void CleanDeath()
    {
        Instantiate(cleanCoder, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
