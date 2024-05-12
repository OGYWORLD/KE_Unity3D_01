using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 회전
/*
 * 
 * 
 * 
 * 
 * 
 */
#endregion

public class RotateCube : MonoBehaviour
{
    #region 전역 변수

    public GameObject target = null;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateSample_01();
        RotationAroundSample();
    }

    void RotateSample_01()
    {
        // 제자리 회전

        // 1. 오일러각: 축을 기준으로 각도 만큼 회전 (기본적으로 각도는 고정되어 있다)
        this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 2. 절대 각도
        // 인자로 들어온 벡터의 오일러 값을 쿼터니언으로 변환 -> 파라미터는 주로 실수 / 벡터
        // 쿼터니언은 단독으로 실행할 수 없다. -> 불필요한 참조 관계가 생긴다.(나중에 경험을 해보도록)
        Quaternion target = Quaternion.Euler(45.0f, 45.0f, 45.0f); // 프로퍼티가 아닐까 의심
        this.transform.rotation = target;

        // 3. 
        // Rotate vs rotation 차이점
        this.transform.Rotate(Vector3.up * 60.0f);
    }

    void RotationSample_02()
    {
        // AngelAxis:축 주위를 앵글만큼 회전한 로테이션을 생성하고 반환
        // 중심 축이 되는 axis가 y축일 경우 y축에 대한 회전값은 변하지 않고
        // x, z의 값만 변한다.

        this.transform.rotation *= Quaternion.AngleAxis(1.5f, Vector3.up);
    }

    void RotationAroundSample()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 100 * Time.deltaTime);
    }
}
