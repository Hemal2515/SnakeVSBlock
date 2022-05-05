using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public NotifiertSO notifiertSO;
    private SnakeMovement snakeMovement1;

    [SerializeField] private float BodySpeed;
    [SerializeField] private float MoveSpeed;


    void Start()
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
            case GameState.GamePlay:
               
                //HeadPrefab.SetActive(true);
                snakeMovement1.BodySpeed = 5f;
                snakeMovement1.MoveSpeed = 5f;

                break;
            default:
                break;
        }
    }
    public void GetSnakeHead(SnakeMovement snakeMovement)
    {
        snakeMovement1 = snakeMovement;
     
    }
}
