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
        _canvasGroup.alpha = _gameManager.CurrentState == GameManager.GameState.Playing ? 1 : 0;
    }
}
