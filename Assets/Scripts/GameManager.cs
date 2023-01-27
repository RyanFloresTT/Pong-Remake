using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Start,
        Playing,
        Paused,
        GameOver
    }
    private GameState _currentState;

    // Update is called once per frame
    private void Update()
    {
        switch (_currentState)
        {
            case GameState.Start:
                // Display start screen
                break;
            case GameState.Playing:
                // Update game logic
                break;
            case GameState.Paused:
                // Display pause menu
                break;
            case GameState.GameOver:
                // Display game over screen
                break;
        }
    }

    public bool IsInStart()
    {
        return _currentState == GameState.Start;
    }
    public bool IsInPlay()
    {
        return _currentState == GameState.Playing;
    }
    public bool IsInPaused()
    {
        return _currentState == GameState.Paused;
    }
    public bool IsInGameOver()
    {
        return _currentState == GameState.GameOver;
    }

    public GameState GetCurrentState()
    {
        return _currentState;
    }

    public void SetState(GameState gameState)
    {
        _currentState = gameState;
    }
}
