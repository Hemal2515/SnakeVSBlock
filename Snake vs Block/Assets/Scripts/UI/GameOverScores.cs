using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScores : MonoBehaviour
{
    public Text text;
   
    

    // Update is called once per frame
    void Update()
    {

        text.text = Score.instance.score.ToString();
    }
}
