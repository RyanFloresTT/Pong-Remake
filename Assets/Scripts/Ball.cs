using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IHasShaderProperties
{
    private GameManager _gameManager;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject playerOnePaddle;
    [SerializeField] private GameObject playerTwoPaddle;
    [SerializeField] private int _speed = 10;
    [SerializeField] private int _resetDelay = 1;
    [SerializeField] private int _bounceCount = 0;

    // Set a flag to make sure we aren't setting a velocity each update call
    private bool _velocitySet = false;

    // Grab Reference to the AddAllIn1Shader script
    [SerializeField] private Material _playerMaterial;

    // Awake is called before start()
    private void Awake()
    {
        // Get references to the Game Manager and the Rigidbody2D on self
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_gameManager.currentState == GameManager.GameState.Playing && !_velocitySet)
        {
            // Set flag to true
            _velocitySet = true;

            // Generate a random direction
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            
            // Clamp Y Value to not be straight up or down
            if ( y > .5f)
            {
                Mathf.Clamp(y, 0, .5f);
            }
            
            if ( y <= 0)
            {
                Mathf.Clamp(y, -.5f, 0);
            }

            Vector2 direction = new Vector2(x, y).normalized;

            // Set the ball's velocity
            _rb.velocity = direction * _speed;
        }

        ToggleShaderProperties();

    }
    // Toggles The Glow based on the bounce count
    public void ToggleShaderProperties()
    {
        if (_bounceCount >= 10)
        {
            _playerMaterial.SetFloat("_Glow", 3f);
        }
        else if (_bounceCount < 10)
        {
            _playerMaterial.SetFloat("_Glow", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == playerOnePaddle || collision.gameObject == playerTwoPaddle)
        {
            _bounceCount++;
        }
    }
    
    public IEnumerator EnterOutOfBounds()
    {
        Debug.Log("EnteredOutOfBounds");
        // Reset Transform and Velocity right away so the ball is still visible to players, then after 1 second, reset the velocity
        transform.position = Vector3.zero; 
        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(_resetDelay);
        ResetBall();
    }

    // Reset Ball, and bounceCount to 0
    private void ResetBall()
    {
        _bounceCount = 0;
        _velocitySet = false;
    }
}
