using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;

    public static GameManager instance;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public UnityEvent onGameOver;

    [SerializeField] private Canvas gameOverCanvas;

    public enum GameState {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        
        instance = this;

        onGameOver.AddListener(GameOver);
        gameOverCanvas.enabled = false;
    }

    private void Start() {
        if (levels.Length > 0) {
            ChangeState(GameState.Briefing, levels[currentLevelIndex]);
        }
    }

    public void ChangeState(GameState state, LevelManager level) {
        currentState = state;
        currentLevel = level;

        switch (currentState) {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitiateLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing() {
        Debug.Log("Briefing Started");

        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void InitiateLevel() {
        Debug.Log("Level Started");

        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel() {
        Debug.Log("Level in " + currentLevel.gameObject.name);
    }

    private void CompleteLevel() {
        Debug.Log("Level Completed");

        // Go to the next level
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }

    private void GameOver() {
        Debug.Log("Game Over");
        gameOverCanvas.enabled = true;
    }

    private void GameEnd() {
        Debug.Log("Game and ended, you win!");
    }

    /*// Midterm Edit
    public void PickedUpFuse(string fuseColour) {
        switch (fuseColour) {
            case "Blue":
                hasBlueFuse = true;
                Debug.Log("picked up blue fuse");
                break;
            case "Red":
                hasRedFuse = true;
                Debug.Log("picked up red fuse");
                break;
            case "Green":
                hasGreenFuse = true;
                Debug.Log("picked up green fuse");
                break;
        }
    }

    public bool HasFuse(string fuseColour) {
        switch (fuseColour) {
            case "Blue":
                return hasBlueFuse;
            case "Red":
                return hasRedFuse;
            case "Green":
                return hasGreenFuse;
            default:
                return false;
        }
    }*/

    public void GameOverEvent() {
        Debug.Log("GAME OVER EVENT TRIGGERED! INVOKING...");
        onGameOver.Invoke();
    }

}

/*[SerializeField] private string fuseColourString;
GameManager.instance.PickedUpFuse(fuseColourString);*/