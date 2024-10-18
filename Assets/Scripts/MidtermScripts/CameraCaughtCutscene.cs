using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraCaughtCutscene : CutsceneBehaviour {
    protected override void CutsceneFinished(PlayableDirector director) {
        GameManager.instance.onGameOver?.Invoke();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered trigger zone");
            PlayCutscene();
        }
    }
}
