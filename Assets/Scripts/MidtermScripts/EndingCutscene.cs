using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class EndingCutscene : CutsceneBehaviour {

    [SerializeField] LevelManager lastLevel;

    protected override void CutsceneFinished(PlayableDirector director) {
        GameManager.instance.ChangeState(GameManager.GameState.GameEnd, lastLevel);
        //lastLevel.EndLevel();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayCutscene();
        }
    }
}
