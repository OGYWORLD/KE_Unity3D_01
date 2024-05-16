using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingCar : MonoBehaviour
{
    private float power = 10.0f;
    private Ray ray;

    public GameObject RightFrontWheel = null;
    public GameObject LeftFrontWheel = null;
    public GameObject RightBackWheel = null;
    public GameObject LeftBackWheel = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Driving();
    }

    void Driving()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, -0.5f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(0.0f, 0.0f, -0.5f));

            MakeWheelVertical();
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, 0.5f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(0.0f, 0.0f, 0.5f));

            MakeWheelVertical();
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 velocity = new Vector3(-0.5f, 0.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));

            MakeWheelHorizontal();
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 velocity = new Vector3(0.5f, 0.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));

            MakeWheelHorizontal();
        }

        else if(Input.GetKey(KeyCode.Q))
        {
            Vector3 velocity = new Vector3(0.5f, 0.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));

            this.transform.localEulerAngles += new Vector3(0.0f, -0.5f, 0.0f);
            MakeWheelHalfHorizontal();
        }

        else if(Input.GetKey(KeyCode.E))
        {
            Vector3 velocity = new Vector3(-0.5f, 0.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;

            this.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));

            this.transform.localEulerAngles += new Vector3(0.0f, 0.5f, 0.0f);

            MakeWheelRHalfHorizontal();
        }

    }

    void MakeWheelVertical()
    {
        RightFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        LeftFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        RightBackWheel.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        LeftBackWheel.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
    }

    void MakeWheelHorizontal()
    {
        RightFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
        LeftFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
        RightBackWheel.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
        LeftBackWheel.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
    }

    void MakeWheelHalfHorizontal()
    {
        RightFrontWheel.transform.localEulerAngles = new Vector3(0.0f, -45.0f, 90.0f);
        LeftFrontWheel.transform.localEulerAngles = new Vector3(0.0f, -45.0f, 90.0f);
        RightBackWheel.transform.localEulerAngles = new Vector3(0.0f, -45.0f, 90.0f);
        LeftBackWheel.transform.localEulerAngles = new Vector3(0.0f, -45.0f, 90.0f);
    }

    void MakeWheelRHalfHorizontal()
    {
        RightFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 45.0f, 90.0f);
        LeftFrontWheel.transform.localEulerAngles = new Vector3(0.0f, 45.0f, 90.0f);
        RightBackWheel.transform.localEulerAngles = new Vector3(0.0f, 45.0f, 90.0f);
        LeftBackWheel.transform.localEulerAngles = new Vector3(0.0f, 45.0f, 90.0f);
    }
}
