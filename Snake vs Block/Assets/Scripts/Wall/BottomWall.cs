using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    public GameObject bottomWall;
    public static BottomWall instaces;
    private void Start()
    {
        instaces = this;   
    }
}
