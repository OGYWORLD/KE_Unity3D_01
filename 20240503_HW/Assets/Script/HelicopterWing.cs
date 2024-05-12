using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterWing : MonoBehaviour
{
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WingTurn();
    }

    void WingTurn()
    {
        float CurVelocity = GetComponentInParent<Rigidbody>().velocity.magnitude;

        transform.RotateAround(target.transform.position, Vector3.up, CurVelocity * Time.deltaTime * 10.0f);

        if(transform.parent.position.y > 20.0f)
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 200.0f);
        }
    }
}
