
using UnityEngine;


public class SnakeSpawner : MonoBehaviour
{
    public SnakeMovement snakeHeadPrefab;
    public Transform snakeParent;
    public GamePlay gamePlay;

    public CameraFollow cameraFollow;
    public MainMenu mainMenu;
    public SnakeMovement snakeMovement;
    // Start is called before the first frame update
    public void Awake()
    {
        SpawnSnakeHead();
    }


    // Spawn Snake Body
    public void SpawnSnakeHead()
    {
        if (snakeMovement.snakeBody.Count <= 0)
        {
            snakeMovement = Instantiate(snakeHeadPrefab,snakeParent);
            snakeMovement.AddSnakeHead(snakeMovement);
            mainMenu.Head(snakeMovement);
            //snakeMovement.snakeBody.Add(snakeMovement.gameObject);
            cameraFollow.GetTarget(snakeMovement.gameObject);
            gamePlay.GetSnakeHead(snakeMovement);
           
        }

    }
}