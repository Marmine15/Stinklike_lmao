using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

    public class PlayerController : MonoBehaviour
    {
        private InputManager _input;
        private Rigidbody2D _rigidbody2D;

        public float moveSpeed;
    
        public int maxHealth;
        public int currentHealth;
        public float damageCooldown;
        private float _damageCooldownTimer;
        public bool isKnockedBack = false;
        private Animator animator;
        
        private void Start()
        {
            _input = GetComponent<InputManager>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
            currentHealth = maxHealth;

            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (isKnockedBack)
            {
                StartCoroutine(KnockBack());
                return; 
            }
            _rigidbody2D.linearVelocityX = _input.Horizontal *  moveSpeed;
            
            animator.SetFloat("xVelocity", Math.Abs(_rigidbody2D.linearVelocity.x));
        }

        

        public void TakeDamage()
        {
            if (Time.time > _damageCooldownTimer)
            {
                currentHealth -= 1;
                _damageCooldownTimer = Time.time + damageCooldown;
            }
            if(currentHealth <= 0)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                print("death");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage();
            }
        }

        private IEnumerator KnockBack()
        {
            yield return new WaitForSeconds(2f);
            print("game resumed?");
            isKnockedBack = false;
        }
    }
