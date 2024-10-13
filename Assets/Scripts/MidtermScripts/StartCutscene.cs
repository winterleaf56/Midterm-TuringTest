using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using System.Net;
using Unity.Mathematics;

public class StartCutscene : CutsceneBehaviour
{
    /*[SerializeField] private Transform player;
    [SerializeField] private PlayableDirector director;*/

    [SerializeField] private Transform endPoint;

    /*public UnityEvent onCutsceneTrigger;
    public UnityAction onCutsceneFinished;*/

    /*public override void PlayCutscene() {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        ToggleScripts(false);

        director.Play();
        director.stopped += CutsceneFinished;
    }*/

    protected override void PlayCutscene() {
        base.PlayCutscene();
    }

    protected override void CutsceneFinished(PlayableDirector director) {
        /*MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        ToggleScripts(true);*/

        base.CutsceneFinished(director);

        player.position = endPoint.position;
        player.rotation = endPoint.rotation.normalized;
    }

    void ToggleScripts(bool choice) {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts) {
            script.enabled = choice;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered trigger zone");
            PlayCutscene();
        }
    }
}
