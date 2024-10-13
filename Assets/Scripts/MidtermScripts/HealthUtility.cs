using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthUtility {
    public static Health GetHealthComponent(Transform hitTransform) {
        while (hitTransform != null) {
            Health health = hitTransform.GetComponent<Health>();
            if (health != null) {
                return health;
            }

            hitTransform = hitTransform.parent;
        }
        return null;
    }

    public static void DamagePlayer(Health playerHealth, int damage) {
        playerHealth.DeductHealth(damage);
        Debug.Log($"Damaging for {damage} health");
    }
}
