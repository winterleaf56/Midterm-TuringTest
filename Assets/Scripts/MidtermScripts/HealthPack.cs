using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthPack : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Health playerHealth = HealthUtility.GetHealthComponent(other.transform);
            if (playerHealth != null) {
                playerHealth.AddHealth(100);
            }
            
            Destroy(gameObject);
        }
    }
}
