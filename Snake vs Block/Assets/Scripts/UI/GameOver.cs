using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Text text;
    public Button quitBtn;
    public Button restartBtn;
    public NotifiertSO notifiertSO;

    private void Start()
    {
        quitBtn.onClick.AddListener(GameQuit);
        restartBtn.onClick.AddListener(GameRestart);
    }

    private void OnEnable()
    {
       
        notifiertSO.OnGameStateChange += OnGameState;
    }

    private void OnDisable()
    {
        notifiertSO.OnGameStateChange -= OnGameState;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
        notifiertSO.CurrentGameState = GameState.MainMenu;
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void OnGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GameOver:
                text.text = Score.instance.score.ToString();
                break;
            default:
                break;
        }
    }

}
