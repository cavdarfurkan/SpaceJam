using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private int health;
    private int hitDamage;
    private int exp;

    private GameObject expSystem;

    private void Start()
    {
        expSystem = GameObject.FindGameObjectWithTag("ExpSystem");

        if (gameObject.name == "meteorSmall(Clone)")
        {
            health = 2;
            hitDamage = 20;
            exp = 1;
        }
        if (gameObject.name == "meteorLarge(Clone)")
        {
            health = 4;
            hitDamage = 30;
            exp = 3;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<Player>().TakeDamage(hitDamage);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        expSystem.GetComponent<ExpSystem>().GrantXp(exp);
    }
}
