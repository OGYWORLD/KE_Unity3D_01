using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveFoward : MonoBehaviour
{
    public void Update()
    {
        var cubePosition = gameObject.transform.position;
        cubePosition.z += 5.0f * Time.deltaTime;

        gameObject.transform.position = cubePosition;
    }
 
}
