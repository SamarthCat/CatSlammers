using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Transform ptf;
    bc bc;
    bool die = true;
    

    void Start()
    {
        bc = GameObject.Find("HealthBar").GetComponent<bc>();
        ptf = GameObject.Find("Player").GetComponent<Transform>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" && die)
        {
            bc.PHealth = 0f;
        }
    }

    void Update()
    {
        if (!bc.eisAlive)
        {
            die = false;
        }

        if (ptf.position.y <= -500)
        {
            bc.PHealth = 0f;
        }

    }
}
