using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MakeWheelLotation();
    }

    void MakeWheelLotation()
    {
       float CurVelocity = GetComponentInParent<Rigidbody>().velocity.magnitude;
       this.transform.Rotate(Vector3.up * CurVelocity);
    }
}
