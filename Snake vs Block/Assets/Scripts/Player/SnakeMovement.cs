using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    private float snakeSpeed = 15f;
    float h, v;
    public List<GameObject> snakeCircleList = new List<GameObject>();
    public int SnakeCircleCount => snakeCircleList.Count;
    public GameObject snakePrefab;

    private int startSnakeCircle = 4;

    public GameObject gamePlayCanvas;
    public GameObject gameOverCanvas;
    public Block block;

    public SnakeBody snakeBody;


    public void Start()
    {
        //Spawn Starting Snake
        snakeCircleList.Add(gameObject);
        for (int i = 1; i < startSnakeCircle; i++)
        {
            snakeCircleList.Add(Instantiate(snakePrefab));
        }
        

    }
    public void Update()
    {
        // Given Input according to Android
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, 0);
        }
        transform.position += new Vector3(0, 0.03f, 0);


        //Show number on Snake
        textMeshPro.text = snakeCircleList.Count.ToString();
        SnakeMove();
    }

    public void FixedUpdate()
    {
        //Given position of snake circle
        for (int i = snakeCircleList.Count - 1; i > 0; i--)
        {
            snakeCircleList[i].transform. position = snakeCircleList[i - 1].transform.position + new Vector3(0, -0.4f, 0);
        }
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnakeBody")
        {
            AudioManager.instances.ColorBallTouch();
            SnakeBody snakeBody = collision.GetComponent<SnakeBody>();
            for(int i=0; i<snakeBody.currentNum; i++)
            {
               SpawnSnakeCircle();
            }
        }
    }

    void SpawnSnakeCircle()
    {
        GameObject snakeCircle = Instantiate(snakePrefab);
        snakeCircle.transform. position = snakeCircleList[snakeCircleList.Count - 1].transform.position;
        snakeCircleList.Add(snakeCircle);
    }

    public void ChangeToGameOver()
    {
        if (snakeCircleList.Count <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SnakeMove()
    {
        float maxX = Camera.main.orthographicSize * Screen.width / Screen.height;

        if (snakeCircleList.Count > 0)
        {
            if (snakeCircleList[0].transform. position.x > maxX) //Right pos
            {
                snakeCircleList[0].transform. position = new Vector3(maxX - 0.05f, snakeCircleList[0].transform. position.y, snakeCircleList[0].transform. position.z);
            }
            else if (snakeCircleList[0].transform. position.x < -maxX) //Left pos
            {
                snakeCircleList[0].transform. position = new Vector3(-maxX + 0.05f, snakeCircleList[0].transform. position.y, snakeCircleList[0].transform. position.z);
            }
        }
    }
}
