using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        StartCoroutine(fire());
    }

    IEnumerator fire()
    {
        while (true)
        {
            Instantiate(prefab);
            yield return new WaitForSeconds(2);
        }
    }


    void Update()
    {
        
    }
}
