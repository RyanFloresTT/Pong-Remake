using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _score = 0;
    // Grab a reference to the ball script
    private Ball ballScript;
    [SerializeField] private GameObject ball;

    void Awake()
    {
        ballScript = ball.GetComponent<Ball>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == ball)
        {
            StartCoroutine(ballScript.EnterOutOfBounds());
            Debug.Log("Collision Detected");
            _score++;
            _scoreText.text = _score.ToString();
        }
    }
}
