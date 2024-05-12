using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHelicopter();
    }

    void MoveHelicopter()
    {
        float zInput = Input.GetAxis("Vertical");

        float zSpeed = zInput * 50.0f;
        
        if(this.transform.position.y < 20)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -zSpeed);
        }
        else
        {
            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * 50.0f;

            this.GetComponent<Rigidbody>().velocity = new Vector3(-xSpeed, 0.0f, -zSpeed);
        }

        if(Input.GetKey(KeyCode.E))
        {
            this.GetComponent<Rigidbody>().AddForce(0.0f, 1000.0f, 0.0f);
        }
        else { DownHelicopter(); }

        if (Input.GetKey(KeyCode.Q))
        {
            this.GetComponent<Rigidbody>().AddForce(0.0f, -1000.0f, 0.0f);
        }
        else { DownHelicopter(); }
    }

    void DownHelicopter()
    {
        this.GetComponent<Rigidbody>().AddForce(0.0f, -100.0f, 0.0f);
    }
}
