using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth
{
    private float currentHealth;
    private float maxHealth;

    public Action<float> OnHealthUpdate;

    public EnemyHealth(float maxHealth, float currentHealth) {
        Debug.Log("New health created");
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;

        OnHealthUpdate?.Invoke(currentHealth);
    }

    public EnemyHealth() {

    }

    public float GetHealth() {
        return currentHealth;
    }

    public void TakeDamage(float damage) {
        Debug.Log("EnemyHealth logging damage at: " + damage);
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthUpdate?.Invoke(currentHealth);
    }


}
