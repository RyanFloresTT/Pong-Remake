using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] CanvasGroup canvasGroup;
    private int _playerOneScore;
    private int _playerTwoScore;
    [SerializeField] private TextMeshProUGUI playerOneScore;
    [SerializeField] private TextMeshProUGUI playerTwoScore;

    public int PlayerOneScore
    {
        get => _playerOneScore;
        set
        {
            _playerOneScore += value;
            playerOneScore.text = PlayerOneScore.ToString();
        }
    }
    public int PlayerTwoScore
    {
        get => _playerTwoScore;
        set
        {
            _playerTwoScore += value;
            playerTwoScore.text = PlayerTwoScore.ToString();
        }
    }
    

    // Cache Variables
    private void Awake()
    {
        // Grab Reference to the Game Manager
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        canvasGroup.alpha = _gameManager.IsInPlay() ? 1 : 0;
    }
}
