using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int moveSpeed = 10;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // This is the left paddle
        if(transform.position.x <= 0)
        {
            // Handle usage of 'W' or 'A' for Upward movement
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
            {
                // Move the paddle up
                Vector2 newPos = transform.position;
                newPos.y += moveSpeed * Time.deltaTime;
                rb.MovePosition(newPos);
            }
            // Handle usage of 'S' or 'D' for Downward Movement
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Move the paddle down
                Vector2 newPos = transform.position;
                newPos.y -= moveSpeed * Time.deltaTime;
                rb.MovePosition(newPos);
            }
        }
        // This is the right paddle
        else
        {
            // Handle usage of 'Up Arrow' or 'Left Arrow' for Upward movement
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Move the paddle up
                Vector2 newPos = transform.position;
                newPos.y += moveSpeed * Time.deltaTime;
                rb.MovePosition(newPos);
            }
            // Handle usage of 'Down Arrow' or 'Right Arrow' for Downward Movement
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                // Move the paddle down
                Vector2 newPos = transform.position;
                newPos.y -= moveSpeed * Time.deltaTime;
                rb.MovePosition(newPos);
            }
        }
    }
}