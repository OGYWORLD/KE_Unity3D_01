using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    IEnumerable func;
    UnityEngine.Coroutine BulletCoroutine;
    bool isFlying = true;
    Transform playerPos;

    void Awake()
    {
        // 호출 순서가 start가 밀릴 수 있어서 Awake에 넣어준다.
        playerPos = FindObjectOfType<PoolPlayer>().gameObject.transform;
        transform.position = playerPos.position; // 유니티는 transform을 따로 가져오는 것이 불가능


    }

    // 오브젝트 풀링의 활성화/비활성화를 위해 만듦
    // 오브젝트 풀링와 GC의 관계 찾아보기
    void OnEnable()
    {
        func = Move();
        BulletCoroutine = StartCoroutine("func");
        transform.position = playerPos.position;
    }

    void OnDisenable()
    {
        StopCoroutine("func"); // 코루틴 꺼주기
    }

    IEnumerable Move()
    {
        StartCoroutine("Stop");

        while(isFlying)
        {
            transform.Translate(transform.forward * 10.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame(); // 한 프레임만 동작시키고 while 끝내기
        }

        gameObject.SetActive(false);
        isFlying = true;
    }

    IEnumerable Stop()
    {
        yield return new WaitForSeconds(2.0f);
        isFlying = false;
    }
}
