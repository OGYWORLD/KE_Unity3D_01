using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MoveCube : MonoBehaviour
{
    #region 전역 변수

    public GameObject cubeObject = null;
    public float moveSpeed = 5.0f;

    #endregion

    // 타 컴포넌트와는 독립적으로 동작하는 객체
    // Start is called before the first frame update
    void Start()
    {
        // MoveSmaple_01();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveSmaple_02();

        MoveSample_03();
        CubeJump();
    }

    void MoveSmaple_01()
    {
        // 월드 좌표계를 변환할때 사용
        transform.position = new Vector3(0.0f, 5.0f, 0.0f);

        // 로컬 좌표계를 변환할때 사용
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f)); // Translate가 들어가는 것은 로컬 좌표계
    }

    void MoveSmaple_02()
    {
        //float moveDelta = moveSpeed * Time.deltaTime;

        //Vector3 pos = this.transform.position; // 월드

        //pos.z += moveDelta;

        //this.transform.position = pos;

        // ==========

        // 로컬
        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta); // 정규화 벡터의 forward

        // 유니티에서는 정규화 벡터를 지원한다.
        // 벡터 = 크기 + 방향
        // 정규화 벡터들의 특징은 모두 노멀라이즈가 되어있다. -> 노말라이즈: 벡터의 정규화 = 단위 벡터
        // Vector3(1, 1, 1) => 크기가 1인 벡터 = 단위 벡터 = 방향만 담고있는 = 유니티에서는 벡터1이라고 말한다.

        // 왜 정규화를 시키는가, 왜 단위 벡터를 사용하는가
        // 벡터의 크기가 들쭉날쭉하다, 벡터의 크기가 크면 연산량이 커진다 -> 낭비다
        // 벡터가 중첩될 여지가 생긴다 => 벡터의 크기가 커진다.

        /*
         * Vector3(1, 0, 0) // Vector3.Right
         * Vector3(-1, 0, 0) // Vector3.Left
         * 
         * Vector3(0, 1, 0) // Vector3.Up
         * Vector3(0, -1, 0) // Vector3.Down
         * 
         * Vector3(0, 0, 1) // Vector3.Forward
         * Vector3(0, 0, -1) // Vector3.Back
         * 
         * Vector3(0, 0, 0) // Vector3.zero (원점 - 이동x)
         * Vector3(1, 1, 1) // Vector3.one (세축으로 이동 (동시이동))
         * 
         * 
         * 
         * <관련 클래스 멤버>
         * Vector3.Dot(A, B)        내적
         * Vector3.Cross(A, B)      외적
         * Vector3.Distance         거리차이 (A와 B의 거리차이)
         * Vector3.Angle            각도 차이(Degree)
         * 
         * 
         * 
         * <관련 인스턴스 멤버>
         * Vector3.Normalize()      정규화(단위벡터로 만들기)
         * Vector3.Magintude()      벡터의 길이를 반환하는 프로퍼티
         * Vector3.SqrMagnitude()   벡터의 길이 제곱을 알려주는 프로퍼티 -> 빠르다
         * 
         */

    }

    void MoveSample_03()
    {
        var cubePosition = cubeObject.transform.position;

        /* GetAxis / GetAxisRaw
         * 넘겨 받는 매개 변수의 문자열을 통해서 키보드나 조이스틱의 입력 값을 -1 ~ +1 사이의 값으로 반환
         * 
         * GetAxis:
         * 즉각적인 반응을 원할 때(정수)
         * -1, 0, 1로만 반응
         * 반응이 빠른 게임에 들어감
         * 
         * 
         * GetAxisRaw:
         * 부드러운 반응을 원할 때(실수)
         * 
         */

        float fDeltaX = Input.GetAxisRaw("Horizontal");
        float fDeltaZ = Input.GetAxisRaw("Vertical");

        Debug.LogFormat("DelatX: {0}", fDeltaX);
        Debug.LogFormat("DelatZ: {0}", fDeltaZ);

        cubePosition.x += fDeltaX * 5.0f * Time.deltaTime;
        cubePosition.z += fDeltaZ * 5.0f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubePosition.x -= 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cubePosition.x += 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            cubePosition.z += 5.0f * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cubePosition.z -= 5.0f * Time.deltaTime;
        }

        cubeObject.transform.position = cubePosition;
    }

    void CubeJump()
    {
        if(Input.GetMouseButtonDown(0)) // 왼쪽 마우스
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 0.5f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().velocity = velocity;
        }

        if(Input.GetMouseButton(1)) // 오른쪽 마우스
        {
            float power = 10.0f;

            Vector3 velocity = new Vector3(0.0f, 2.0f, 0.0f);
            velocity *= power;
            this.GetComponent<Rigidbody>().AddForce(velocity); // AddForce는 힘이 누적되기 때문에 마우스에 가해지는 힘만큼 올라감
        }
    }
}
