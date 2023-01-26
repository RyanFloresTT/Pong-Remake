using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameManager _gameManager;

    // Cache Variables
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Enable or disable the button depending on state
        if (_gameManager.IsInStart())
        {
            // Enable Button on Start State
            gameObject.SetActive(true);
        }
        else
        {
            // Disable the Button
            gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        // OnClick() Calls this function to make the Game State 'Playing'
        _gameManager.CurrentState = GameManager.GameState.Playing;
    }

}
