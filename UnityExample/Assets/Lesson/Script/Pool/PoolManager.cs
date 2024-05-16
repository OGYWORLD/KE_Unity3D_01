using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 전방 선언과 비슷, 그러나 유니티에는 전방 선언 이라는 개념이 없음
    // 이렇게 쓰면 start나 awake에서 연결해줘야함
    ObjectPooling instancePool;
    PoolPlayer player;
    bool pressed = false;
    

    void Start()
    {
        // 이게 연결 해준 거임
        // FindObjectOfType은 하이어라키에서 찾겠다는 것
        instancePool = FindObjectOfType<ObjectPooling>();
        player = FindObjectOfType<PoolPlayer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            player.pressed = true;
            pressed = true;
        }

        if(player.pressed)
        {
            StartCoroutine("Shoot");
            player.pressed = false;
        }
    }

    // transform, coroutine, animation 꼭 신경써서 포폴에 넣기

    // Enumerable => 참조카운터 사용하겠다
    IEnumerable Shoot()
    {
        while (true)
        {
            instancePool.SpawnObj();

            // tuple과 비슷 -> n개 이상의 반환값을 줄 수 있기 때문
            // 비동기이기 때문에 update와 별개로 돌아감
            // 비동기와 동기를 섞어쓰는 것은 좋지 않다
            yield return new WaitForSeconds(0.3f);
        }
    }
}

