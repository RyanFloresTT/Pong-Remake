using UnityEngine;

public class LeftPaddle : MonoBehaviour, IHasShaderProperties, IIsAPaddle
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private OutOfBounds outOfBounds;
    private Material _paddleMaterial;
    private Rigidbody2D _rb;
    private readonly string _shaderMaterial = "_HologramBlend";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _paddleMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        Move();
        ToggleShaderProperties();
    }

    public void Move()
    {
        // Handle usage of 'W' or 'A' for Upward movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            // Move the paddle up
            Vector2 newPos = transform.position;
            newPos.y += moveSpeed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }
        // Handle usage of 'S' or 'D' for Downward Movement
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Move the paddle down
            Vector2 newPos = transform.position;
            newPos.y -= moveSpeed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }
    }

    public void ToggleShaderProperties()
    {
        var currentScore = outOfBounds.GetCurrentScore();
        switch (currentScore)
        {
            case >= 5:
                Debug.Log("mt5");
                _paddleMaterial.SetFloat(_shaderMaterial, 1f);
                break;
            case <= 5:
                Debug.Log("lt5");
                _paddleMaterial.SetFloat(_shaderMaterial, 0f);
                break;
        }
    }
}