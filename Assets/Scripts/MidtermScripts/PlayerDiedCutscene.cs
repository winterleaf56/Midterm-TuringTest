using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayerDiedCutscene : CutsceneBehaviour {

    public UnityEvent onPlayerDeadTrigger;

    public static PlayerDiedCutscene Instance;

    protected override void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        onPlayerDeadTrigger.AddListener(PlayCutscene);
    }

    protected override void CutsceneFinished(PlayableDirector director) {
        Debug.Log("Cutscene Finished, Game Over");
        GameManager.instance.onGameOver.Invoke();
    }

    public void TriggerDeathScene() {
        onPlayerDeadTrigger?.Invoke();
    }

}