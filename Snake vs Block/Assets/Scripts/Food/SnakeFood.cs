using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeFood : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public int onFoodNum;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "BottomWall")
        {
            Destroy(this.gameObject);
        }

    }


}
