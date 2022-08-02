using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool godMode;

    private bool isAlive;

    public int maxHealth;
    public int health;

    public HealthBar healthBar;

    void Start()
    {
        isAlive = true;

        maxHealth = 100 + (PlayerPrefs.GetInt("healthPoints", 0)*10);
        health = maxHealth;
        healthBar.SetMaxHealthBarValue(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealthBarValue(health+damage, health);

        if (health <= 0)
        {
            if(!godMode)
                Die();
        }
    }

    public void Heal(int healAmount)
    {
        if (isAlive)
        {
            health += healAmount;
            healthBar.SetHealthBarValue(health-healAmount, health);
        }
    }

    public void FullHeal()
    {
        if (isAlive)
        {
            healthBar.SetHealthBarValue(health, maxHealth);
            health = maxHealth;
        }
    }

    private void Die()
    {
        isAlive = false;
        Destroy(gameObject);

        // Load GameOverScene
        SceneManager.LoadScene("GameOverScene");
    }
}
