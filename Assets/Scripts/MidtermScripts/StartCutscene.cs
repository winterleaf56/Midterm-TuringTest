using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using System.Net;
using Unity.Mathematics;

public class StartCutscene : CutsceneBehaviour {

    [SerializeField] private Transform endPoint;

    protected override void PlayCutscene() {
        base.PlayCutscene();
    }

    protected override void CutsceneFinished(PlayableDirector director) {
        base.CutsceneFinished(director);

        player.position = endPoint.position;
        player.rotation = endPoint.rotation.normalized;
    }

    /*void ToggleScripts(bool choice) {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts) {
            script.enabled = choice;
        }
    }*/

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered trigger zone");
            PlayCutscene();
        }
    }
}
