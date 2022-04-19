using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    public TMP_Text tMP_Text;
    public GameObject particlePrefab;
    private int i;
    public int num;

    Coroutine a;

    private void Update()
    {
        if(BottomWall.instaces.bottomWall.transform.position.y > transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (a == null)
            {
                SnakeMovement snakeMovement= collision.collider.GetComponent<SnakeMovement>();
                if (snakeMovement == null)
                    return;
                a = StartCoroutine(DecreseBlockNumber(snakeMovement.SnakeCircleCount,snakeMovement));
            }
        }
    }


    public  void OnCollisionExit2D(Collision2D collision)
    {
     //   StopCoroutine(a);
    }
    IEnumerator DecreseBlockNumber(int snakeCount,SnakeMovement snakeMovement)
    {
        i = int.Parse(tMP_Text.text);
        while(i > 0)
        {
            //Decrese Block Number
            tMP_Text.text = (i).ToString();
            i--;

            //Remove snake circle from snakeCircleList and Instatiate Particle
            
            GameObject go = snakeMovement.snakeCircleList[snakeMovement.SnakeCircleCount - 1];
            AudioManager.instances.BlockTouch();
            GameObject storeParticle = Instantiate(particlePrefab, snakeMovement.transform.position, Quaternion.identity);
            snakeMovement.snakeCircleList.Remove(go);
            snakeMovement.ChangeToGameOver();
            Destroy(go);
            

            //Increse Score
            Score.instance.score ++ ;
            yield return new WaitForSeconds(0.2f);
            Destroy(storeParticle);
        }
        if(i< snakeCount)
            Destroy(this.gameObject);
        
        yield return null;

    }

    

}
