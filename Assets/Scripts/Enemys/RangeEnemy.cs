using System;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [Header("Targets")]
    public Transform target;
    private Rigidbody2D _rigidbody2D;

    [Header("Ranges")]
    [SerializeField]public float attackRange;

    [Header("Attacking")]
    [SerializeField] public float attackSpeed;
    public float attackIntrevalCounter;
    public float shootTime;
    public bool shooting;
    
    [Header("Bulletsettings")]
    [SerializeField]private GameObject _bullet;
    [SerializeField]private float _bulletcooldown;
    public Transform bulletSpawn;
    private float _bulletTimer;
    public float BulletSpeed;
    public float bulletLifetime;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
