using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 스크립트 -> 노션정리

/// <summary>
/// Assert나 전처리기 메시지(Pragma Message)
/// 습관들여서 많이 쓰기
/// </summary>


/// <summary>
/// 시작 클래스
/// </summary>
/// <param name= "현재 상태"> MonoBehaviour를 상속받는 기본클래스.</param>

public class Example_02 : MonoBehaviour
{
    void Awake()
    {
        print("Awake Call");
    }


    // Start is called before the first frame update
    void Start()
    {
        print("Start Call");
        Debug.Log(this.gameObject.name + " 입니다.");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update Call");

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        
    }

    void FixedUpdate()
    {
        // 기본 시간
    }

    void OnDisable()
    {
        
    }

    void OnDestroy()
    {
        
    }

    void OnBecameInvisible()
    {
        
    }

    void OnBecameVisible()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));

        Gizmos.DrawWireSphere(this.transform.position, 1.0f);
    }

    IEnumerator StartCorutine()
    {
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
        yield return new WaitForSeconds(10.0f);
    }
}
