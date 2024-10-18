using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class FinalPuzzleController : CutsceneBehaviour {
    [SerializeField] private TMP_Text greenNumber;
    [SerializeField] private TMP_Text blueNumber;
    [SerializeField] private TMP_Text redNumber;

    [SerializeField] private Door door;

    public void DetermineCompletion() {
        if (greenNumber.text == "7" && blueNumber.text == "2" && redNumber.text == "5") {
            Debug.Log("Puzzle Complete!");
            PlayCutscene();
        } else {
           Debug.Log("Puzzle Incomplete");
        }
    }

    protected override void CutsceneFinished(PlayableDirector director) {
        base.CutsceneFinished(director);
        door.UnlockDoor();
        door.OpenDoor(true);
    }
}
