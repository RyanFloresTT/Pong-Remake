using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Start,
        Playing,
        Reset,
        Paused,
        GameOver
    }
    public GameState CurrentState;

    // Update is called once per frame
    private void Update()
    {
        switch (CurrentState)
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
        return CurrentState == GameState.Start;
    }
    public bool IsInPlay()
    {
        return CurrentState == GameState.Playing;
    }
    public bool IsInPaused()
    {
        return CurrentState == GameState.Paused;
    }
    public bool IsInGameOver()
    {
        return CurrentState == GameState.GameOver;
    }
}
