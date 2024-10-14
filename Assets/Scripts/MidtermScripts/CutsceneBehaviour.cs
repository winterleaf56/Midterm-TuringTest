using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public abstract class CutsceneBehaviour : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] private PlayableDirector director;

    public UnityEvent onCutsceneTrigger;
    public UnityAction onCutsceneFinished;

    protected virtual void PlayCutscene() {
        //MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        PlayerUtilities.Instance.ToggleScripts(false);

        director.Play();
        director.stopped += CutsceneFinished;
    }

    protected virtual void CutsceneFinished(PlayableDirector director) {
        //MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        PlayerUtilities.Instance.ToggleScripts(true);
    }

    /*void ToggleScripts(bool choice) {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts) {
            script.enabled = choice;
        }
    }*/

    protected virtual void Awake() {

    }
}
