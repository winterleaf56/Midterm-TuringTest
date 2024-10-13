using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(DamagePlayer());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            StopCoroutine(DamagePlayer());
        }
    }

    IEnumerator DamagePlayer() {
        while (true) {
            yield return new WaitForSeconds(0.1f);
            health.DeductHealth(5);
        }
    }
}
