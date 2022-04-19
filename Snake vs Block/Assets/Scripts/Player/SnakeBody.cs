using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeBody : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    public int currentNum;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        if(BottomWall.instaces.bottomWall.transform.position.y > transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
    

}
