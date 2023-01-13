using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Start,
        Playing,
        Paused,
        GameOver
    }
    public GameState currentState;

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
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
}
