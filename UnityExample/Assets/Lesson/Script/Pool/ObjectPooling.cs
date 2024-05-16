using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오브젝트 풀링
#endregion

#region 인스펙터 속성
/*
 * 
 */
#endregion

public class ObjectPooling : MonoBehaviour
{
    int pointer;
    // List<T> Value = new List<>();
    // 가변 배열(멤버 함수이고 추가 및 삭제가 용이하다.)
    // 같은 데이터 타입만 저장 가능하니 이는 곧 박싱과 언박싱을 수행하지 않는다는 얘기
    List<GameObject> pool; // 참조 카운드 -> 스마트 포인터
    [SerializeField]
    GameObject pooledObject;

    void Start()
    {
        // 유니티 수학 함수 주의할점 -> Max는 포함되지 않는다.
        // 랜던값 설정
        int size = Random.Range(10, 15);

        pointer = 0;
        pool = new List<GameObject>();

        for(int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pooledObject, Vector3.zero, pooledObject.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pool.Add(obj);
        }


    }

    public void SpawnObj()
    {
        // 스마트 포인터 찾아서 정리하기<shared, unique, weak>
        if(pointer != pool.Count) // 원시 주소의 개수만 전달 = 참조 카운터
        {
            pool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            pointer = 0;
            pool[pointer].SetActive(true);
            pointer++;
        }
    }
}
