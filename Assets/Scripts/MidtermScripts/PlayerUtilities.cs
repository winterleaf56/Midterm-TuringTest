using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerUtilities : MonoBehaviour
{
    [SerializeField] private Transform player;

    public static PlayerUtilities Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    public void ToggleScripts(bool choice) {
        MonoBehaviour[] scripts = player.GetComponentsInChildren<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts) {
            if (script is not Health && script is not SignalReceiver) {
                script.enabled = choice;
            }
                
        }
    }
}
