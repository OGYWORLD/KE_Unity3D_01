using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunRotationInput();
    }

    void GunRotationInput()
    {
        if(Input.GetMouseButton(0))
        {
            this.transform.eulerAngles += new Vector3(0.0f, -2.0f, 0.0f);
        }

        else if (Input.GetMouseButton(1))
        {
            this.transform.eulerAngles += new Vector3(0.0f, 2.0f, 0.0f);
        }
    }
}
