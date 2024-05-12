using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ObjectController : MonoBehaviour
{
    #region 전역 변수

    public GameObject cubeObject = null;
    public float moveSpeed = 2.0f;

    #endregion

    public void Awake()
    {
        Debug.Log("Your Light, Unity");

        // GetComponent<T> 활용
        // var는 auto 같은 것 (약한 형식 검사(유추) - 강한 형식 검사는 데이터타입을 명시(실수 방지) -> C#에만 존재)
        // var는 지역 변수로만 선언해야됨 -> 선언과 동시에 반드시 초기화를 수행해야 한다.
        var transformObject = cubeObject.GetComponent<Transform>(); 
        transformObject.position = new Vector3(4.0f, 8.0f, -4.0f);

        var selfTransform = gameObject.GetComponent<Transform>();
        selfTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // 모두 동일한 기능 - 프로퍼티를 통해 접근
        //this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //cubeObject.transform.position = new Vector3(0.1f, 0.1f, 0.1f);

        //
        var oCubeObject = GameObject.Find("MoveCube");
        oCubeObject.AddComponent<CMoveFoward>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
