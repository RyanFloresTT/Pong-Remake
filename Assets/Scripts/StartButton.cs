using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Grab Reference to the Game Manager
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enable or disable the button depending on state
        if (gameManager.currentState == GameManager.GameState.Start)
        {
            // Enable Button on Start State
            gameObject.SetActive(true);
        }
        else
        {
            // Disable the Button
            gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        // OnClick() Calls this function to make the Game State 'Playing'
        gameManager.currentState = GameManager.GameState.Playing;
    }

}
