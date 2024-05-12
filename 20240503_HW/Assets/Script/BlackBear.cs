using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatWatching());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RepeatWatching()
    {
        LookRandom();
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(RepeatWatching());
    }

    void LookRandom()
    {
        float randomX = Random.Range(-180.0f, 180.0f);
        float randomZ = Random.Range(-180.0f, 180.0f);

        Vector3 directionToTarget = new Vector3(randomX, 0.0f, randomZ);


        this.transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
    }
}
