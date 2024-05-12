using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PatrollSample();
    }

    void PatrollSample()
    {
        // PingPong = 최소값과 최대값을 사이를 반복해주는 함수
        // PingPong(float t, float length)
        // Time.time -> 선언이 된 시점에서 카운트를 시작한다 (Play 시간 누적)
        transform.position = new Vector3(Mathf.PingPong(Time.time, 4), transform.position.y, transform.position.z);
    }
}
