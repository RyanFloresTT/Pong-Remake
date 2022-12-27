using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager gameManager;
    public Rigidbody2D rb;
    public int speed = 10;
    public int resetDelay = 1;
    public int bounceCount = 0;
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
    void FixedUpdate()
    {
        if (gameManager.currentState == GameManager.GameState.Playing && !velocitySet)
        {
            // Set flag to true
            velocitySet = true;
            // Generate a random direction
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            
            // Clamp Y Value to not be straight up or down
            if ( y > 0)
            {
                Mathf.Clamp(y, .5f, 1f);
            }
            
            if ( y <= 0)
            {
                Mathf.Clamp(y, -1f, -.5f);
            }

            Vector2 direction = new Vector2(x, y).normalized;

            // Set the ball's velocity
            rb.velocity = direction * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            bounceCount++;
        }
    }
    
    void OnBecameInvisible()
    {
        Debug.Log("Invis");
        // Reset Transform and Velocity right away so the ball is still visible to players, then after 1 second, reset the velocity
        transform.position = Vector3.zero; 
        rb.velocity = Vector2.zero;      
        Invoke("ResetBall", resetDelay);
    }

    // Reset Ball, and bounceCount to 0
    void ResetBall()
    {
        bounceCount = 0;
        velocitySet = false;
    }
}
