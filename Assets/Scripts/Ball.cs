using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour, IHasShaderProperties
{
    private Rigidbody2D _rb;
    [SerializeField] private GameObject playerOnePaddle;
    [SerializeField] private GameObject playerTwoPaddle;
    [SerializeField] private int speed = 10;
    [SerializeField] private int resetDelay = 1;
    [SerializeField] private int bounceCount = 0;
    [SerializeField] private Material playerMaterial;
    [SerializeField] private string shaderName = "_Glow";
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        switch (bounceCount)
        {
            case >= 10:
                playerMaterial.SetFloat(shaderName, 3f);
                break;
            case < 10:
                playerMaterial.SetFloat(shaderName, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var paddle = collision.gameObject.GetComponent<IIsAPaddle>();
        if (paddle == null) return;
        bounceCount++;
        ToggleShaderProperties();
    }
    
    public IEnumerator EnterOutOfBounds()
    {
        ResetBall();
        yield return new WaitForSeconds(resetDelay);
        SetBallVelocity();
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero; 
        _rb.velocity = Vector2.zero;
        bounceCount = 0;
    }
}
