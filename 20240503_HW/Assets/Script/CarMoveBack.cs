using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveBack : MonoBehaviour
{
    public GameObject CarObject = null;
    public float MoveSpeed = 5.0f;
    bool IsCollison = false;

    // Update is called once per frame
    void Start()
    {
    }

    void Update()
    {
        if (!IsCollison) MoveBack();
    }

    void MoveBack()
    {
        float power = 10.0f;

        Vector3 velocity = new Vector3(0.0f, 0.0f, 1.0f);
        velocity *= power;
        this.GetComponent<Rigidbody>().AddForce(velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Box"))
        {
            IsCollison = true;
        }
    }
}
