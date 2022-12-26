using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameManager gameManager;
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        // Grab Reference to the Game Manager
        gameManager = GameObject.FindObjectOfType<GameManager>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enable or disable the Score depending on state
        if (gameManager.currentState == GameManager.GameState.Playing)
        {
            // "Enable" Score on Playing State
            canvasGroup.alpha = 1;

        }
        else
        {
            // "Disable" Score on anything else
            canvasGroup.alpha = 0;
        }
    }
}
