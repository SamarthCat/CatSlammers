using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    public bc bc;

    void Start()
    {
        PlayerPrefs.SetString("do2", "yes");
        bc = GameObject.FindGameObjectWithTag("bc").GetComponent("bc") as bc;
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            bc.PHealth -= 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
    }
}
