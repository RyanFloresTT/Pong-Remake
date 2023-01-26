using TMPro;
using UnityEngine;
public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int maxScore = 10;
    private GameManager _gameManager;
    private Ball _ballScript;

    // Grab a reference to the ball script
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (currentScore >= maxScore)
            _gameManager.CurrentState = GameManager.GameState.GameOver;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        _ballScript = collider.gameObject.GetComponent<Ball>();
        if (_ballScript == null) return;
        StartCoroutine(_ballScript.EnterOutOfBounds());
        currentScore++; 
        scoreText.text = currentScore.ToString();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
