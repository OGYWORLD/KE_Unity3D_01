using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region 프리팹

#endregion

public class CPrefabExample : MonoBehaviour
{
    #region
    public GameObject BulletObject = null;


    #endregion
 
    void Update()
    {
        FireSample_03();
    }

    void FireSample_01()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // prefab이 나오면 이 친구가 나온다.
            // Instantiate(): 오브젝트를 복사한다 (객체를 동적으로 생성)
            // 원본 오브젝트를 복사하여 클론 반환해주는 메서드
            // Instantiate는 오버로딩이 많지만 다음 형태를 기억하자!
            // 인수: 대상 오브젝트, 오브젝트 위치, 오브젝트 회전값
            //Instantiate(BulletObject, transform.position, transform.rotation);
            // Destroy(BulletObject); 코스트가 큰 Destroy

            // 리지드 바디: 받을 대상 객체가 필요하다.
            // Instantiate는 받을 대상이 존재하지 않는다.
            GameObject bullet = Instantiate(BulletObject, transform.position, transform.rotation);
            float bulletPower = 1000.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
        }
    }

    void FireSample_02()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 생성되는 위치가 겹치면 총알이 날라가지 않으므로 위치를 변경
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.7f, transform.rotation);
            float bulletPower = 1500.0f;
            Vector3 direction = new(0.0f, 0.3f, 0.5f);

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Destroy(bullet, 3.0f); // clone 제거
        }
    }

    void FireSample_03()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletObject, transform.position + transform.forward * 0.7f, transform.rotation);
            float bulletPower = 4000.0f;

            // 발사대가 바라보면 방향으로 총알이 날라갈 수 있도록
            // TransformDirection: 오브젝트가 어떤 방향을 바라 보는지를 각도를 얻고자 할 때 사용한다.
            Vector3 shootForward = bullet.transform.TransformDirection(Vector3.forward);

            bullet.GetComponent<Rigidbody>().AddForce(bulletPower * shootForward);
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Destroy(bullet, 5.0f); // clone 제거
        }
    }
}
