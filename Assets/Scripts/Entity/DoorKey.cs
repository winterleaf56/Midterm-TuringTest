using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour
{
    public UnityEvent onKeyPickup;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            onKeyPickup?.Invoke();
            Destroy(gameObject);
        }
    }
}
