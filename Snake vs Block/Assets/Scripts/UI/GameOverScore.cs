using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScore : MonoBehaviour
{
    public Text text;
    public Score score;
    
    void Update()
    {

        text.text = score.score.ToString();
    }
}
