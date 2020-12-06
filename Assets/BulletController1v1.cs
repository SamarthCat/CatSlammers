using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController1v1 : MonoBehaviour
{
    public bool isFiring = false;
    public float vel;
    public Transform tf;
    public Transform ptf;
    public string fd;
    public BoxCollider2D collider;
    public bool enablecollider = false;
    public int ecc = 0;
    public bool dontFlip;
    public string self;
    public string enemy;
    public local1v1 l1v1;

    // Start is called before the first frame update
    void Start()
    {

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != self)
        {
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            isFiring = false;

            if (col.gameObject.name == enemy)
            {
                l1v1.bullethit(col);
            }

            if (col.gameObject.tag == "Destroyable")
            {
                col.gameObject.SetActive(false);
                l1v1.asrc.PlayOneShot(l1v1.beeclip, 1f);
            }

        }


    }

    public void fire()
    {
        if (!isFiring)
        {
            if (ptf.localScale.x == 1)
            {
                fd = "r";
            }
            else if (ptf.localScale.x == -1)
            {
                fd = "l";
            }

            l1v1.asrc.PlayOneShot(l1v1.shootclip, 1f);
            isFiring = true;
            enablecollider = true;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (enablecollider)
        {
            ecc += 1;
        }

        if (ecc == 23)
        {
            collider.enabled = true;
            ecc = 0;
            enablecollider = false;
        }

        if (isFiring)
        {
            if (fd == "r")
            {
                tf.position = new Vector2(tf.position.x + (vel / 10), tf.position.y);
            }
            else if (fd == "l")
            {
                tf.position = new Vector2(tf.position.x - (vel / 10), tf.position.y);
            }

        }
        else if (dontFlip)
        {
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            tf.localScale = new Vector3(2f, 2f, 2f);
            collider.enabled = false;
        }
        else
        {
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            tf.localScale = new Vector3(ptf.localScale.y * 2, ptf.localScale.x * 2, 2f);
            collider.enabled = false;
        }

    }
}
