using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas gamePlayCanvas;
    public Canvas gameOverCanvas;
    public NotifiertSO notifiertSO;

    private void Start()
    {
        notifiertSO.CurrentGameState = GameState.MainMenu;
    }
    private void OnEnable()
    {
        notifiertSO.OnGameStateChange += OnGameState;
    }
    private void OnDisable()
    {
        notifiertSO.OnGameStateChange -= OnGameState;
    }

    public void OnGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                mainMenuCanvas.enabled = true;
                gamePlayCanvas.enabled = false;

                break;
            case GameState.GamePlay:
                gamePlayCanvas.enabled = true;
                mainMenuCanvas.enabled = false;
                break;
            case GameState.GameOver:
                gamePlayCanvas.enabled = false;
                gameOverCanvas.enabled = true;
                break;
        }
    }

    
    
}
