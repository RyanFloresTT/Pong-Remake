using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OOB : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Debug.Log("Collision Detected");
            score++;
            scoreText.text = score.ToString();
        }
    }
}
