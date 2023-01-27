using UnityEngine;

public class RightPaddle : MonoBehaviour, IHasShaderProperties, IIsAPaddle
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
        // Handle usage of 'Up Arrow' or 'Left Arrow' for Upward movement
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the paddle up
            Vector2 newPos = transform.position;
            newPos.y += moveSpeed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }
        // Handle usage of 'Down Arrow' or 'Right Arrow' for Downward Movement
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            // Move the paddle down
            Vector2 newPos = transform.position;
            newPos.y -= moveSpeed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }  
    }

    public void ToggleShaderProperties()
    {
        var currentScore = scoreManager.PlayerTwoScore;
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