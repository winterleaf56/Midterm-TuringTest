using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using System.Net;
using Unity.Mathematics;

public class StartCutscene : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayableDirector director;

    [SerializeField] private Transform endPoint;

    public UnityEvent onCutsceneTrigger;
    public UnityAction onCutsceneFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCutscene() {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        /*foreach (MonoBehaviour script in scripts) {
            script.enabled = false;
        }*/

        ToggleScripts(false);

        director.Play();
        director.stopped += CutsceneFinished;
    }

    private void CutsceneFinished(PlayableDirector director) {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        /*foreach (MonoBehaviour script in scripts) {
            script.enabled = true;
        }*/

        ToggleScripts(true);

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
