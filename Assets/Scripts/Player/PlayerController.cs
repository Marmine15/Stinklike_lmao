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
        public bool isKnockedBack = false;

        private void Start()
        {
            _input = GetComponent<InputManager>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
            currentHealth = maxHealth;
        }

        private void FixedUpdate()
        {
            if (isKnockedBack)
            {
                StartCoroutine(KnockBack());
                return; 
            }
            _rigidbody2D.linearVelocityX = _input.Horizontal *  moveSpeed;
            _rigidbody2D.linearVelocityY = _input.Vertical *  moveSpeed;
        }

        public void TakeDamage(int amount)
        {
            if (currentHealth > 0)
            {
                currentHealth -= amount;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private IEnumerator KnockBack()
        {
            yield return new WaitForSeconds(2f);
            print("game resumed?");
            isKnockedBack = false;
        }
    }
