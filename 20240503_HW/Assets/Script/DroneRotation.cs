using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRotation : MonoBehaviour
{
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationAround();
    }

    void RotationAround()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}
