using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
   
    //Update Camwra per frame
    public void LateUpdate()
    {
        if (target)
        {
            if (target.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z) ;
            }
        }
    }

    public void GetTarget(GameObject go)
    {
        target = go;
    }
}
