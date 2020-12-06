using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
using Pathfinding;
using UnityEngine.Rendering.PostProcessing;

public class Boss2 : MonoBehaviour
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
    public string status = "unshot";
    public bc bc;
    public int putback = 0;
    public AudioSource aus;
    public RectTransform rt;
    public CameraShaker cs;
    public Chicken ch;
    public bool zoomOut = true;
    public PostProcessVolume ppv;
    public PostProcessProfile bossPP;
    public PostProcessProfile normalPP;

    void Start()
    {
        ppv.profile = normalPP;
        StartCoroutine(speech());
        ch.enabled = false;
    }

   

    IEnumerator firing()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(5);
            status = "shot";
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
        sun.enabled = false;
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
        yield return new WaitForSeconds(1);
        tmp.text = "";
        cm.Vel = 60;
        cs.RestRotationOffset = new Vector3(0, 0, 180);
        rt.localPosition = new Vector2(-450, -450);
        rt.localScale = new Vector2(-1, -1);
        ppv.profile = bossPP;
        StartCoroutine(firing());
        StartCoroutine(pulse());
        ch.enabled = true;
    }

    IEnumerator pulse()
    {
        for (int i = 0; i < 20000; i++)
        {
            if (zoomOut)
            {
                for (int i1 = 0; i1 < 20; i1++)
                {
                    yield return new WaitForSeconds(0.001f);
                    cam.orthographicSize -= 0.01f;
                }
                zoomOut = false;
            }
            else
            { 
                for (int i2 = 0; i2 < 20; i2++)
                {
                    yield return new WaitForSeconds(0.001f);
                    cam.orthographicSize += 0.01f;
                }
                zoomOut = true;
            }

        }
    }


    void Update()
    {



    }
}
