using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class MBulletController : NetworkBehaviour
{
    #if UNITY_ANDROID
        bool isMobile = true;
    #elif UNITY_IOS
        bool isMobile = true;
    #else
        bool isMobile = false;
    #endif

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
    public AudioSource audio;
    public AudioClip shootclip;
    public GameObject goodPlayer;
    public MMove goodMove;
    public Button _fire;

    // Start is called before the first frame update
    void Start()
    {
        //isMobile = true;
        if (isMobile)
        {
            _fire = GameObject.FindGameObjectWithTag("fireButton").GetComponent<Button>();
            _fire.onClick.AddListener(fire);
        }
        goodMove = goodPlayer.GetComponent(typeof(MMove)) as MMove;
        ptf = goodPlayer.transform;
        tf = transform;
        collider = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent(typeof(AudioSource)) as AudioSource;
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (!goodMove.hasAuthority) { return; }
        if (col.gameObject != goodPlayer)
        {
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            isFiring = false;

            if (col.gameObject.name == "Player(Clone)")
            {
                if (col.gameObject != goodPlayer)
                {
                    goodMove.IHitSomeone(col.gameObject);
                }
            }

        }


    }



    public void fire()
    {
        if (!isFiring && goodMove.hasAuthority)
        {
            if (ptf.localScale.x == 1)
            {
                fd = "r";
            }
            else if (ptf.localScale.x == -1)
            {
                fd = "l";
            }

            audio.PlayOneShot(shootclip, 1f);
            isFiring = true;
            enablecollider = true;

        }
    }

    void FixedUpdate()
    {
        
        if (Input.GetKeyDown("f") | Input.GetKeyDown("joystick button 2"))
        {
            fire();
        }

        if (enablecollider)
        {
            ecc = ecc + 1;
        }

        if (ecc == 32)
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
            collider.enabled = false;
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            tf.localScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            collider.enabled = false;
            tf.position = new Vector2(ptf.position.x + 0.04f, ptf.position.y - 0.18f);
            tf.localScale = new Vector3(ptf.localScale.y*2, ptf.localScale.x*2, 2f);
        }

    }
}
