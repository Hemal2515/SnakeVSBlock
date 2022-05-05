using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainMenuBtn;
    public NotifiertSO notifiertSO;
    public SnakeMovement snakeMovement;
    private SnakeMovement snakeMovement1;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn.onClick.AddListener(GameStart);
       
    }
    private void OnEnable()
    {
        notifiertSO.OnGameStateChange += OnGameState;
    }

    private void OnDisable()
    {
        notifiertSO.OnGameStateChange -= OnGameState;
    }


    public void GameStart()
    {
        notifiertSO.CurrentGameState = GameState.GamePlay;
        notifiertSO.OnGameStateChange += OnGameState;
    }
    public void OnGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                Debug.Log("MainMenu");
               snakeMovement1.BodySpeed = 0f;
               snakeMovement1.MoveSpeed = 0f;
                break;
            default:
                break;
        }
    }

    public void Head(SnakeMovement snakeMovement)
    {
        snakeMovement1 = snakeMovement;
    }
}
