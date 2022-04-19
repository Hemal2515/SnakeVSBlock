using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Block blockPrefab;
    public SnakeBody snakeBodyPrefab;
    public Transform camera;
    public List<Color> ColorName = new List<Color>();

    private int number;
    private float YaxisRange;
    private float XaxisRange;
    
    private int onBlockNumber;

    private float screenWidthNum;
    private float screenWidthNum1;

    private int colorIndexNumber;

    Vector2 pos;
    void Start()
    {
        /*GameObject g = new GameObject();
        g.transform.position = new Vector3(Screen.width / 2, 0, 0);
        g.transform.position = Camera.main.ScreenToWorldPoint(g.transform.position);*/

        //Calculation of screen point
        GameObject g2 = new GameObject();
        g2.transform.position = new Vector3(0, Screen.height / 2, 0);
        g2.transform.position = Camera.main.ScreenToWorldPoint(g2.transform.position);
        screenWidthNum = g2.transform.position.x;
        screenWidthNum += 0.5825f;
        screenWidthNum1 = screenWidthNum;
    }

   public void Update()
    {
        if(pos.y < camera.position.y)
        {
            BlockGenerate();
        }
    }
    void BlockGenerate()
    {
        
            number = Random.Range(1, 6);
            YaxisRange = Random.Range(camera.position.y + 10f, camera.position.y + 13f);

            for (int i = 0; i < number; i++)
            {
            //Given Number and Color on block
                onBlockNumber = Random.Range(1, 20);
                colorIndexNumber = onBlockNumber / ColorName.Count;

                GetBlockColor(colorIndexNumber);
            }
       
            SpawnSnakeBody();

            screenWidthNum = screenWidthNum1;
        pos += new Vector2(0, 4f);
   }

    void GetBlockColor(int colorIndex)
    {
        Block block = Instantiate(blockPrefab,new Vector3(screenWidthNum,YaxisRange,0),Quaternion.identity);
        block.gameObject.GetComponent<SpriteRenderer>().color = ColorName[colorIndex];
        block.tMP_Text.text = onBlockNumber.ToString();
        screenWidthNum += 1.12f;
    }

    void SpawnSnakeBody()
    {
        //Spawn Snakebody point to increase snake length 
        float a = Random.Range(1, 2);
        int snakeBodyNumber = Random.Range(1, 6);
        XaxisRange = Random.Range(-2.30f, 2.30f);
        SnakeBody snakeBody = Instantiate(snakeBodyPrefab, new Vector3(XaxisRange, YaxisRange + a, 0), Quaternion.identity);
        snakeBody.textMeshPro.text = snakeBodyNumber.ToString();
        snakeBody.currentNum = snakeBodyNumber;

    }
}
