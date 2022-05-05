using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Notifier")]
public class NotifiertSO : ScriptableObject
{
    [SerializeField]private GameState gameState;
    public delegate void GameStateChange(GameState gameState);
    public event GameStateChange OnGameStateChange;


    
    public GameState CurrentGameState {
        get {return gameState; }
        set { gameState = value;
            OnGameStateChange?.Invoke(gameState);
        }
    }
        
}

public enum GameState
{
    MainMenu,
    GamePlay,
    GameOver
}
