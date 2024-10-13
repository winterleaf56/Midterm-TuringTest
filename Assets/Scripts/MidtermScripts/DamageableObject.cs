using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DamageableObject : MonoBehaviour {
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private LayerMask rocketLayer;

    [SerializeField] private float maxHealth;

    private EnemyHealth enemyHealth;

    public UnityEvent onDeath;

    protected virtual void Awake() {
        enemyHealth = new EnemyHealth(maxHealth, maxHealth);
    }

    public void OnCollided(Collision col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            TakeDamage(20);
        } else if (col.gameObject.layer == LayerMask.NameToLayer("Rocket")) {
            TakeDamage(100);
        }
    }

    protected virtual void TakeDamage(float damage) {
        Debug.Log("TAKING DAMAGE: " + damage);
        enemyHealth.TakeDamage(damage);

        if (enemyHealth.GetHealth() <= 0) {
            OnDeath();
        }
    }

    protected virtual void OnDeath() {
        onDeath?.Invoke();
    }

    private void OnCollisionEnter(Collision collision) {
        OnCollided(collision);
    }

    public float GetHealth() {
        return enemyHealth.GetHealth();
    }

    protected virtual void Start() {

    }

    protected virtual void Update() {

    }
}
