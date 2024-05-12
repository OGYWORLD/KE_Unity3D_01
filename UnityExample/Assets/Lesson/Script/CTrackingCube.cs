using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrackingCube : MonoBehaviour
{
    #region 
    public GameObject target = null;
    public float distance = 5.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Ray ray;

    // Update is called once per frame
    void Update()
    {
        TrackingSample();
    }

    void TrackingSample()
    {
        ray = new Ray
        { origin = this.transform.position,
          direction = this.transform.forward,
        };

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        Vector3 dirToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
    }
}
