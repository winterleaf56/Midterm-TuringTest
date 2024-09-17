using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLight : MonoBehaviour
{
    [SerializeField] private CameraEnemy parentCamera;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            parentCamera.onPlayerInLight?.Invoke();
        }
    }
}
