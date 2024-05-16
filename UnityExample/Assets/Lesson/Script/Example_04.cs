//#define EXAMPLE_TYPE_VALUE // 매크로는 최상단에 기입해야지 컴파일 오류 안 남
//#define EXAMPLE_TYPE_REFERENCE
#define EXAMPLE_TYPE_NULLABLE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region C#

#endregion

public class Example_04 : MonoBehaviour
{
    public void Awake()
    {


#if EXAMPLE_TYPE_VALUE

        int nValue = 10;
        float fValue = 3.14f;
        double dValue = 3.14;
        decimal mValue = 3.14m;

        Debug.LogFormat("데이터 출력 {0} {1} {2} {3}", nValue, fValue, dValue, mValue);

#elif EXAMPLE_TYPE_REFERENCE

        object oValue = 10;
        string oString = "HelloFire";

        // $: C# 6.0에서 추가된 기능 -> 문자열 보간 (보간된 문자열로 식별)
        // 2이상의 인덱스부터 2의 엔승 인덱스의 값을 해싱해서 보간한다는 뜻
        // 1. lengh를 구한다
        // 2. 2이상의 인덱스부터 2의 엔승 인덱스 값을 저장해서 이걸로 문자열을 읽겠다는 뜻
        Debug.Log($"데이터 출력 : {oValue}, {oString}");

#else

        int? nValue = null; // 주소 여부 확인
        float? fValue = null;
        System.Nullable<int> nValueB = 10;

        if(nValue.HasValue)
        {
            Debug.Log("정수형 값이 유효");
        }
        else
        {
            Debug.Log("정수형 값이 유효하지 않음");
        }

        if(fValue != null)
        {
            Debug.Log("실수형 값이 유효");
        }
        else
        {
            Debug.Log("실수형 값이 유효하지 않음");
        }

        if(nValueB.HasValue)
        {
            Debug.Log("정수형 값이 유효");
        }
        else
        {
            Debug.Log("정수형 값이 유효하지 않음");
        }

#endif


    }
}
