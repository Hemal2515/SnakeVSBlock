using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] NotifiertSO notifiertSO;
    private void Awake()
    {
        notifiertSO.CurrentGameState = GameState.GamePlay;
    }

    private void Start()
    {
        StartCoroutine(wait());
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.10f);
        notifiertSO.CurrentGameState = GameState.MainMenu;

    }


}
