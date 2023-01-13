using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _score = 0;
    [SerializeField] private GameObject _ball;
    private Ball _ballScript;

    // Grab a reference to the ball script
    private void Awake()
    {
        _ballScript = _ball.GetComponent<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == _ball)
        {
            StartCoroutine(_ballScript.EnterOutOfBounds());
            Debug.Log("Collision Detected");
            _score++;
            _scoreText.text = _score.ToString();
        }
    }
}
