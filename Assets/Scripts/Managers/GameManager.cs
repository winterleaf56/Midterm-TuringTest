using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;

    public static GameManager instance;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public UnityEvent onGameOver;
    public UnityEvent onRestartGame;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameCompleteCanvas;

    [SerializeField] private EndingCutscene endingCutscene;

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
        onRestartGame.AddListener(RestartGame);
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
        gameOverCanvas.SetActive(true);
        PlayerUtilities.Instance.ToggleScripts(false);

        UnlockCursor();
    }

    private void GameEnd() {
        Debug.Log("Game and ended, you win!");

        gameCompleteCanvas.SetActive(true);
        UnlockCursor();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameOverEvent() {
        Debug.Log("GAME OVER EVENT TRIGGERED! INVOKING...");
        onGameOver.Invoke();
    }

}