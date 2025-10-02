using System;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int currentHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite[] healthSprites;
    
    public PlayerController playerController;

    private void Start()
    {
        currentHealth = playerController.maxHealth;
    }
    
    private void Update()
    {
        currentHealth = playerController.currentHealth;
        
        if (currentHealth == 13)
        {
           spriteRenderer.sprite = healthSprites[0];
        }
        else if (currentHealth == 12)
        {
            spriteRenderer.sprite = healthSprites[1];
        }
        else if (currentHealth == 11)
        {
            spriteRenderer.sprite = healthSprites[2];
        }
        else if (currentHealth == 10)
        {
            spriteRenderer.sprite = healthSprites[3];
        }
        else if (currentHealth == 9)
        {
            spriteRenderer.sprite = healthSprites[4];
        }
        else if (currentHealth == 8)
        {
            spriteRenderer.sprite = healthSprites[5];
        }
        else if (currentHealth == 7)
        {
            spriteRenderer.sprite = healthSprites[6];
        }
        else if (currentHealth == 6)
        {
            spriteRenderer.sprite = healthSprites[7];
        }
        else if (currentHealth == 5)
        {
            spriteRenderer.sprite = healthSprites[8];
        }
        else if (currentHealth == 4)
        {
            spriteRenderer.sprite = healthSprites[9];
        }
        else if (currentHealth == 3)
        {
            spriteRenderer.sprite = healthSprites[10];
        }
        else if (currentHealth == 2)
        {
            spriteRenderer.sprite = healthSprites[11];
        }
        else if (currentHealth == 1)
        {
            spriteRenderer.sprite = healthSprites[12];
        }
    }
}
