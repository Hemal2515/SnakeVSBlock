
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeMovement : MonoBehaviour
{ 
    public TextMeshPro snakeSizeText;

    public NotifiertSO notifiertSO;
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 5;
    
    private List<Vector3> PositionsHistory = new List<Vector3>();
    public List<GameObject> snakeBody = new List<GameObject>();
    public int SnakeBodyCount => snakeBody.Count;
    public Transform snakeParent;
    private GameObject getSnakeHead;

    private int startSnakeBody = 4;

    public GameObject BodyPrefab;


    public void Start()
    {
        snakeBody.Add(getSnakeHead);
        for (int i = 0; i < startSnakeBody; i++)
        {
            SpawnSnakeBody();
        }

    }
    public void Update()
    {
        transform.position += transform.up * MoveSpeed * Time.deltaTime;

        // Given Input according to Android       
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, 0);
        }


        Vector2 steerDirection = Input.mousePosition;
        transform.Rotate(Vector3.forward * steerDirection * SteerSpeed * Time.deltaTime);

        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in snakeBody)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            index++;
        }
        
        SnakeMove();

        //Update Snake Length
        snakeSizeText.text = snakeBody.Count.ToString();
        
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnakeFood")
        {
            AudioManager.instances.ColorBallTouch();
            SnakeFood snakeFood = collision.GetComponent<SnakeFood>();
            for(int i=0; i<snakeFood.onFoodNum; i++)
            {
              SpawnSnakeBody();
            }
        }
    }

    //Spawn SnakeBody
    public void SpawnSnakeBody()
    {
        GameObject body = Instantiate(BodyPrefab, snakeParent);

        snakeBody.Add(body);
    }

    
    void SnakeMove()
    {
        float maxX = (Camera.main.orthographicSize * Screen.width / Screen.height)-0.2f;

        if (snakeBody.Count > 0)
        {
            if (snakeBody[0].transform.position.x > maxX) //Right pos
            {
                snakeBody[0].transform.position = new Vector3(maxX - 0.05f, snakeBody[0].transform.position.y, snakeBody[0].transform.position.z);
            }
            else if (snakeBody[0].transform.position.x < -maxX) //Left pos
            {
                snakeBody[0].transform.position = new Vector3(-maxX + 0.05f, snakeBody[0].transform.position.y, snakeBody[0].transform.position.z);
            }
        }
    }

    //GameOver
    public void ChangeToGameOver()
    {
        if (snakeBody.Count <= 0)
        {
            notifiertSO.CurrentGameState = GameState.GameOver;
        }
    }

    //Add Snake Head
    public void AddSnakeHead(SnakeMovement snakeMovement)
    {
        getSnakeHead = snakeMovement.gameObject;
    }
}
