using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public int score = 0;
    

    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
