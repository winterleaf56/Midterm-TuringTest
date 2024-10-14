using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float maxHealth;

    public Action<float> OnHealthUpdated;
    public Action onDeath;

    public bool isDead { get; private set; }

    [SerializeField] private float health;

    void Start()
    {
        health = maxHealth;
        OnHealthUpdated(maxHealth);
    }

    public void DeductHealth(float value) {
        if (isDead) return;

        health -= value;

        if (health <= 0) {
            isDead = true;
            OnDeath();
            onDeath?.Invoke();
            health = 0;
        }

        OnHealthUpdated(health);
    }

    void OnDeath() {
        Debug.Log("Player died");
        GameManager.instance.onGameOver.Invoke();
    }
}
