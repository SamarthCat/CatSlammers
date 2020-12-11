using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BulletController : MonoBehaviour
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
    public bool dontFlip;
    CameraShaker shaker;

    // Start is called before the first frame update
    void Start()
    {
        shaker = Camera.main.gameObject.AddComponent<CameraShaker>();
        shaker.RestPositionOffset = Camera.main.transform.position;
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Player")
        {
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            isFiring = false;

            if (col.gameObject.name == "Enemy")
            {
                bc.bullethit();
            }

            if (col.gameObject.tag == "Destroyable")
            {
                col.gameObject.SetActive(false);
                bc.audio.PlayOneShot(bc.beeclip, 1f);
            }

        }


    }




    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKeyDown("f") | Input.GetKeyDown("joystick button 2"))
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

                bc.audio.PlayOneShot(bc.shootclip, 1f);
                isFiring = true;
                enablecollider = true;

            }
        }



        if (enablecollider)
        {
            ecc = ecc + 1;
        }

        if (ecc == 23)
        {
            collider.enabled = true;
            ecc = 0;
            enablecollider = false;
        }

        if (isFiring)
        {
            if(fd == "r")
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
            tf.localScale = new Vector3(ptf.localScale.y*2, ptf.localScale.x*2, 2f);
            collider.enabled = false;
        }

    }
}
