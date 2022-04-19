using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllButton : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
