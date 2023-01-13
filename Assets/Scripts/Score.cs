using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private GameManager _gameManager;
    private CanvasGroup _canvasGroup;

    // Cache Variables
    private void Awake()
    {
        // Grab Reference to the Game Manager
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Enable or disable the Score depending on state
        if (_gameManager.currentState == GameManager.GameState.Playing)
        {
            // "Enable" Score on Playing State
            _canvasGroup.alpha = 1;

        }
        else
        {
            // "Disable" Score on anything else
            _canvasGroup.alpha = 0;
        }
    }
}
