using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 30f;
    private float currentHealth;

    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Enemy health adjusted: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy is damaged: " + damage + " Remaining health: " + (currentHealth - damage));
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Enemy is dead: " + gameObject.name);
            Die();
        }
    }

    void Die()
    {
        OnDeath?.Invoke();

        Destroy(gameObject);
    }
}