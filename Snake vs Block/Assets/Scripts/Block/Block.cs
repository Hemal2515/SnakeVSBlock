using System.Collections;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public NotifiertSO notifiertSO;
    public TMP_Text tMP_Text;
    public GameObject particlePrefab;
    private int i;

    Coroutine a;
    
    private void OnEnable()
    {
        notifiertSO.OnGameStateChange += OnGameState;
    }


    public void OnGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GameOver:
                //Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BottomWall")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
           SnakeMovement snakeMovement = collision.collider.gameObject.GetComponent<SnakeMovement>();
            snakeMovement.BodySpeed = 1f;
            a = StartCoroutine(DecreaseNumber(snakeMovement));
        }
    }


    public  void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.gameObject.GetComponent<SnakeMovement>().BodySpeed = 5f;
        StopCoroutine(a);
    }
   

    IEnumerator DecreaseNumber(SnakeMovement snakeMovement)
    {
        i = int.Parse(tMP_Text.text);
        GameObject storeSnakeBody;
        while (i > 0)
        {
            //Increse Score
            Score.instance.GetScore();

            //Decrese Block Number
            tMP_Text.text = (i).ToString();
            i--;
            
            //Remove snake body from snakeCircleList and Instatiate Particle
            if(snakeMovement.SnakeBodyCount <= 1)
            {
                storeSnakeBody = snakeMovement.snakeBody[0];
            }
            else
            {
                storeSnakeBody = snakeMovement.snakeBody[1];
            }

            AudioManager.instances.BlockTouch();
            GameObject storeParticle = Instantiate(particlePrefab,snakeMovement.transform.position, Quaternion.identity);
            snakeMovement.snakeBody.Remove(storeSnakeBody);
            snakeMovement.ChangeToGameOver();
            Destroy(storeSnakeBody);

           yield return new WaitForSeconds(0.2f);
            Destroy(storeParticle);
        }
        Destroy(this.gameObject);
    }

}
