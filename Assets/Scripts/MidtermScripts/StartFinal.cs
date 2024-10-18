using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StartFinal : MonoBehaviour
{
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private GameObject redLights;
    [SerializeField] private Door door;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            door.OpenDoor(false);
            directionalLight.SetActive(false);
            redLights.SetActive(true);
        }
    }
}
