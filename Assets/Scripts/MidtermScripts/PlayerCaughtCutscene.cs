using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayerCaughtCutscene : CutsceneBehaviour {
    //public static event UnityAction onPlayerCaught;
    //public event Action OnPlayerCaught;
    //public UnityEvent OnPlayerCaught;

    /*static PlayerCaughtCutscene() {
        onPlayerCaught += InvokePlayerCaught;
    }*/

    /*protected override void Awake() {
        onPlayerCaught += PlayCutscene;
        Debug.Log("PLAYER CAUGHT SUBSCRIBED");
    }*/

/*    private static PlayerCaughtCutscene _instance;

    public static PlayerCaughtCutscene Instance {
        get {
            if (_instance == null) {
                _instance = new PlayerCaughtCutscene();
                _instance.Initialize();
            }
            return _instance;
        }
    }*/

    public UnityEvent onPlayerCaught;

    public static PlayerCaughtCutscene Instance;

    protected override void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(Instance);
            return;
        }

        Instance = this;

        onPlayerCaught.AddListener(PlayCutscene);
    }

    protected override void PlayCutscene() {
        base.PlayCutscene();
        Debug.Log("Player caught cutscene started");
    }

    protected override void CutsceneFinished(PlayableDirector director) {
        base.CutsceneFinished(director);
        Debug.Log("Player caught cutscene ended");
    }

    public void TriggerCutsceneAction() {
        onPlayerCaught?.Invoke();
    }
}
