using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OOB : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    // Grab a reference to the ball script
    Ball ballScript;
    [SerializeField] GameObject ball;

    void Awake()
    {
        ballScript = ball.GetComponent<Ball>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            ballScript.EnteredOOB();
            Debug.Log("Collision Detected");
            score++;
            scoreText.text = score.ToString();
        }
    }
}
