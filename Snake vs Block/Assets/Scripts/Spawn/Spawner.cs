using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Block blockPrefab;
    public SnakeFood snakeFoodPrefab;
    public new Transform camera;
    public List<Color> ColorNames = new List<Color>();

    private int number;
    private float YaxisRange;
    private float foodXaxisRange;
   [SerializeField] private int blockXaxisRange;
    
    private int onBlockNumber;

    private float screenWidthNum;
    private float totalScreeenSize;
    private float blockSize;
    private float halfBlockSize;
    [SerializeField] Transform blockParent;
    [SerializeField] Transform foodParent;
    [SerializeField] private List<float> points;
   [SerializeField] private List<float> tempPoints;

    private int colorIndexNumber;

    Vector2 pos;
   public void Start()
    {
        GameObject screenWidthObj = new GameObject();
        screenWidthObj.transform.position = new Vector3(0, Screen.height / 2, 0);
        screenWidthObj.transform.position = Camera.main.ScreenToWorldPoint(screenWidthObj.transform.position);
        
        totalScreeenSize =Mathf.Abs( (screenWidthObj.transform.position.x + screenWidthObj.transform.position.x) / 5);
        blockSize = Mathf.Abs (totalScreeenSize - 0.1f);
        halfBlockSize = blockSize / 2;
        blockPrefab.transform.localScale = new Vector3(blockSize, blockSize, blockSize);

        screenWidthNum = screenWidthObj.transform.position.x;
        screenWidthNum += halfBlockSize;

        points = new List<float>();
        tempPoints = new List<float>();
        
        for (int i = 0; i < 5; i++)
        { 
            points.Add(screenWidthNum );
            screenWidthNum += totalScreeenSize;
        }
        tempPoints.AddRange( points);
        
        
    }

    public void Update()
    {
        if(pos.y < camera.position.y)
        {
            GetBlockDetail();
        }
        
    }
    void GetBlockDetail()
    {
        number = Random.Range(1, 6);
        YaxisRange = Random.Range(camera.position.y + 10f, camera.position.y + 13f);

        for (int i = 0; i < number; i++)
        {
            //Given Number and Color on block
            SpawnBlock();
        }
        
        SpawnSnakeFood();
       tempPoints.Clear();
        tempPoints.AddRange(points);
        
        pos += new Vector2(0, 4f);
    }

    void SpawnBlock()
    {
        if(Score.instance.score <= 10)
            onBlockNumber = Random.Range(1, 5);
        else if(Score.instance.score >= 30)
            onBlockNumber = Random.Range(10, 30);
        else if(Score.instance.score >= 70)
            onBlockNumber = Random.Range(20, 40);
        onBlockNumber = Random.Range(1, 20);

        blockXaxisRange = Random.Range(0, tempPoints.Count);
        colorIndexNumber = onBlockNumber / ColorNames.Count;
        Block block = Instantiate(blockPrefab, new Vector3(tempPoints[blockXaxisRange], YaxisRange, 0), Quaternion.identity,blockParent);
        block.gameObject.GetComponent<SpriteRenderer>().color = ColorNames[colorIndexNumber];
        block.tMP_Text.text = onBlockNumber.ToString();
        tempPoints.RemoveAt(blockXaxisRange);
    }

    void SpawnSnakeFood()
    {
        //Spawn Snakebodypoint to increase snake length 
        float a = Random.Range(1, 2);
        int foodNumber = Random.Range(1, 6);
        foodXaxisRange = Random.Range(-2.30f, 2.30f);
        SnakeFood snakeFood = Instantiate(snakeFoodPrefab, new Vector3(foodXaxisRange, YaxisRange + a, 0), Quaternion.identity,foodParent);
        snakeFood.textMeshPro.text = foodNumber.ToString();
        snakeFood.onFoodNum = foodNumber;

    }
}
