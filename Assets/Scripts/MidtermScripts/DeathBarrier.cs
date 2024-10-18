using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Health playerHealth = HealthUtility.GetHealthComponent(other.transform);
            HealthUtility.DamagePlayer(playerHealth, 100);
        }
    }
}
