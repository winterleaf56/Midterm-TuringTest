using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class EndingCutscene : CutsceneBehaviour {

    protected override void CutsceneFinished(PlayableDirector director) {
        GameManager.instance.ChangeState(GameManager.GameState.GameEnd, null);
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayCutscene();
        }
    }
}
