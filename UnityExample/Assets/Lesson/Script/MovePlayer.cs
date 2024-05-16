using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0.0f;

    // 유니티 이벤트 메소드는 메모리 차지하니깐(콜백함수라서) 안 쓸거면 지우셈
    // 주석도 안 먹힘

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(-hori * Time.deltaTime * speed, upDown * Time.deltaTime * speed, 0.0f);

        transform.Translate(move);
    }
}
