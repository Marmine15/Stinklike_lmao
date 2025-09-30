using System.Collections;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [Header("Targets")]
    public Transform target;
    private Rigidbody2D _rigidbody2D;

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

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < attackRange)
        {
            if (shooting) return;
            if (attackIntrevalCounter < Time.time)
            {
                StartCoroutine(Shooting());
            }
        }
    }

    private IEnumerator Shooting()
    {
        Vector3 pdirection = Vector3.Cross(transform.position - target.position, Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, pdirection);
        
        shooting = true;
        yield return new WaitForSeconds(shootTime);
        
        var targetPos = target.position;
        _bulletTimer = bulletCooldown;
        var projectileClone =
            Instantiate(bullet, bulletSpawn.position,
                Quaternion.identity);
        projectileClone.TryGetComponent(out Rigidbody2D rb2D);

        projectileClone.transform.right = transform.right.normalized;
        rb2D.linearVelocity = projectileClone.transform.right * bulletSpeed;
        Destroy(projectileClone, bulletLifetime);
        attackIntrevalCounter = Time.time;
        yield return new WaitForSeconds(shootTime);
        shooting = false;
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
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
