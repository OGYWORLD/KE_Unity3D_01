using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputControl : MonoBehaviour
{
    private readonly float inputSpeedMove = 5.0f;
    private readonly float inputSpeedRotate = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputRotation();
        InputRotateMove();
        InputIdentity();
    }

    public void InputRotation()
    {
        float AxisY = Input.GetAxis("Horizontal");

        AxisY = AxisY * inputSpeedRotate * Time.deltaTime;
        this.gameObject.transform.Rotate(new Vector3(0, AxisY, 0));

    }

    public void InputRotateMove()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * inputSpeedRotate * Time.deltaTime;
        move = move * inputSpeedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rotate);
        this.gameObject.transform.Translate(Vector3.forward * move);
    }

    void InputIdentity()
    {
        if(Input.GetMouseButton(1))
        {
            this.transform.localRotation = Quaternion.identity;
        }

    }
}
