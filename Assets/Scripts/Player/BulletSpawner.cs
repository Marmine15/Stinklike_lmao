using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private InputManager _inputSystem;
    
    public Transform spawner;
    public float bulletSpeed;

    private void Start()
    {
        _inputSystem = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (_inputSystem.Attack)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPooler.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = spawner.rotation;
            bullet.SetActive(true);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
