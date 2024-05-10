using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    #region 전역 변수
    public GameObject target = null;
    #endregion

    // Update is called once per frame
    void Update()
    {
        LookAtSample();
    }

    void LookAtSample()
    {
        // 3d에서 거리를 구하는 공식: 끝점 - 시작
        Vector3 directionalToTarget = target.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(directionalToTarget, Vector3.up);
    }
}
