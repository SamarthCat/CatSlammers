using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public bool isFiring = false;
    public float vel;
    public Transform tf;
    public Transform ptf;
    public string fd;
    public bc bc;
    public BoxCollider2D collider;
    public bool enablecollider = false;
    public int ecc = 0;
    public Boss boss;
    public Transform etf;

    // Start is called before the first frame update
    void Start()
    {

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Enemy")
        {

            if (col.gameObject.name == "Player")
            {
                boss.hit();
            }

            boss.nothit();

        }


    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown("k"))
        {
            if (!isFiring)
            {
                if (etf.localScale.x == 1)
                {
                    fd = "r";
                }
                else if (etf.localScale.x == -1)
                {
                    fd = "l";
                }


            }
        }


        if (etf.localScale.x == 1)
        {
            fd = "r";
        }
        else if (etf.localScale.x == -1)
        {
            fd = "l";
        }
    }
}
