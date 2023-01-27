using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour, IHasShaderProperties
{
    [SerializeField] private GameObject playerOnePaddle;
    [SerializeField] private GameObject playerTwoPaddle;
    [SerializeField] private int speed = 10;
    [SerializeField] private int resetDelay = 1;
    [SerializeField] private GameObject leftOutOfBounds;
    [SerializeField] private GameObject rightOutOfBounds;
    [SerializeField] private ScoreManager scoreManager;
    private Rigidbody2D _rb;    
    private int _bounceCount = 0;
    private Material _ballMaterial;
    private readonly string _shaderName = "_Glow";
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ballMaterial = GetComponent<SpriteRenderer>().material;
    }
    
    private void SetBallVelocity()
    {

        var velocityX = Random.Range(-1f, 1f);
        var velocityY = Random.Range(-1f, 1f);

        if (velocityY > .5f)
        {
            velocityY = Mathf.Clamp(velocityY, 0, .5f);
        }

        if (velocityY <= 0)
        {
            velocityY = Mathf.Clamp(velocityY, -.5f, 0);
        }

        var direction = new Vector2(velocityX, velocityY).normalized;

        _rb.velocity = direction * speed;
    }

    public void ToggleShaderProperties()
    {
        switch (_bounceCount)
        {
            case >= 10:
                _ballMaterial.SetFloat(_shaderName, 3f);
                break;
            case < 10:
                _ballMaterial.SetFloat(_shaderName, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var paddle = collision.gameObject.GetComponent<IIsAPaddle>();
        if (paddle == null) return;
        _bounceCount++;
        ToggleShaderProperties();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == leftOutOfBounds)
        {
            scoreManager.PlayerOneScore += 1;
            StartCoroutine(EnterOutOfBounds());
        }

        if (other.gameObject == rightOutOfBounds)
        {
            scoreManager.PlayerTwoScore += 1;
            StartCoroutine(EnterOutOfBounds());
        }
    }

    private IEnumerator EnterOutOfBounds()
    {
        ResetBall();
        yield return new WaitForSeconds(resetDelay);
        SetBallVelocity();
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero; 
        _rb.velocity = Vector2.zero;
        _bounceCount = 0;
    }
}
