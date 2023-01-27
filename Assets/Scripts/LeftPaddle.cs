using UnityEngine;

public class LeftPaddle : MonoBehaviour, IHasShaderProperties, IIsAPaddle
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private ScoreManager scoreManager;
    private Material _paddleMaterial;
    private Rigidbody2D _rb;
    private const string ShaderMaterial = "_HologramBlend";

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
        var currentScore = scoreManager.PlayerOneScore;
        switch (currentScore)
        {
            case >= 5:
                _paddleMaterial.SetFloat(ShaderMaterial, 1f);
                break;
            case <= 5:
                _paddleMaterial.SetFloat(ShaderMaterial, 0f);
                break;
        }
    }
}