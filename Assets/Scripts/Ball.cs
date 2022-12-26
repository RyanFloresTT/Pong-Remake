using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager gameManager;
    public Rigidbody2D rb;
    public int speed = 10;
    // Set a flag to make sure we aren't setting a velocity each update call
    bool velocitySet = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get references to the Game Manager and the Rigidbody2D on self
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentState == GameManager.GameState.Playing && !velocitySet)
        {
            // Set flag to true
            velocitySet = true;
            // Generate a random direction
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 direction = new Vector2(x, y).normalized;

            // Set the ball's velocity
            rb.velocity = direction * speed;
        }
    }
}