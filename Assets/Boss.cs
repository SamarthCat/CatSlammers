using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
using Pathfinding;

public class Boss : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public string msg1 = "How Dare You Insult The Bee Kind...";
    public string msg2 = "Somebody is Going to DIE tonight...";
    public string msg3 = "and its YOU...";
    public Camera cam;
    public CloudMove cm;
    public SpriteRenderer sun;
    public Transform ptf;
    public Transform etf;
    public Transform btf;
    public BoxCollider2D bbc;
    public Rigidbody2D brb;
    public string status = "unshot";
    public SpriteRenderer bsr;
    public bc bc;
    public EnemyBullet eb;
    public int putback = 0;
    public AIPath path;
    public AudioSource aus;

    void Start()
    {
        nothit();
        btf.position = etf.position;
        bsr.enabled = false;
        bbc.enabled = false;
        StartCoroutine(speech());

    }

    public void hit()
    {
        bc.PHealth = bc.PHealth - 1;
        bsr.enabled = false;
        bbc.enabled = false;
        btf.position = etf.position;
        status = "unshot";
    }

    public void nothit()
    {
        bsr.enabled = false;
        bbc.enabled = false;
        btf.position = etf.position;
        status = "unshot";
    }

    IEnumerator firing()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(5);
            status = "shot";
            bsr.enabled = true;
        }

    }

    IEnumerator musicloop()
    {
        yield return new WaitForSeconds(18.5f);
        aus.enabled = true;
    }

    IEnumerator speech()
    {
        tmp.text = msg1;
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
        bc.audio.PlayOneShot(bc.bossmusic, 1f);
        StartCoroutine(musicloop());
        yield return new WaitForSeconds(3);
        tmp.text = msg2;
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
        yield return new WaitForSeconds(3);
        tmp.text = msg3;
        cam.backgroundColor = new Color(0, 0, 0);
        sun.enabled = false;
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
        yield return new WaitForSeconds(1);
        tmp.text = "";
        cm.Vel = 60;
        path.enabled = true;
        StartCoroutine(firing());
    }



    void FixedUpdate()
    {


        if (status == "shot")
        {
            if (putback <= 30)
            {
                putback = 0;
                bbc.enabled = true;
            }
            else
            {
                putback = putback + 1;
            }



            if (eb.fd == "r")
            {
                btf.position = new Vector2(btf.position.x - 0.1f, btf.position.y);
            }
            if (eb.fd == "l")
            {
                btf.position = new Vector2(btf.position.x + 0.1f, btf.position.y);
            }

        }
        else if (eb.fd == "l")
        {
            btf.position = new Vector2 (etf.position.x + 1, etf.position.y);
        }
        else if(eb.fd == "r")
        {
            btf.position = new Vector2(etf.position.x - 1, etf.position.y);
        }


    }
}
