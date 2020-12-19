using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Mirror;
using TMPro;
using Cinemachine;

public class MMove : NetworkBehaviour
{
    public AudioSource src;
    public AudioClip Damaged;
    public AudioClip Hit;
    public Rigidbody2D rb;
    public GameObject bullet;
    //public Joystick js;
    public GameObject[] go;
    float xmov;
    [SerializeField]
    public float vel = 5;
    [SerializeField]
    public Transform tf;
    public SpriteRenderer sr;
    public SpriteRenderer bsr;
    public Sprite cat1;
    public Sprite cat1bullet;
    public MBulletController mbuc;
    public float myHealth = 10;
    public GameObject Win;
    public GameObject Lose;
    public OnNetStart ons;
    public TextMeshProUGUI mine;
    public TextMeshProUGUI otherGuys;
    bool finished = false;

    [Client]
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        ons = GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(OnNetStart)) as OnNetStart;
        Win = ons.Win;
        Lose = ons.Lose;

        Win.SetActive(false);
        Lose.SetActive(false);

        rb = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        GameObject myBullet = Instantiate(bullet);
        mbuc = myBullet.GetComponent(typeof(MBulletController)) as MBulletController;
        mbuc.goodPlayer = gameObject;
        if (!hasAuthority) { return; }
        Camera.main.gameObject.GetComponent<CinemachineVirtualCamera>().Follow = transform;
        mine = GameObject.FindGameObjectWithTag("Destroyable").GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        otherGuys = GameObject.FindGameObjectWithTag("LevelPart").GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;


        sr = gameObject.GetComponent<SpriteRenderer>();
        CmdSyncCat(PlayerPrefs.GetString("currentCat"));

    }

    


    [Command]
    void CmdSyncCat(string cat)
    {
        RpcSyncCat(cat);
    }

    [ClientRpc]
    void RpcSyncCat(string cat)
    {
        sr.sprite = Resources.Load<Sprite>(cat);
    }

    public void IHitSomeone(GameObject person)
    {
        src.PlayOneShot(Hit);
        MMove hitmove = person.GetComponent(typeof(MMove)) as MMove;
        UnAuthSyncHealth(hitmove.myHealth -= 1f, person);
    }

    public void UnAuthSyncHealth(float h, GameObject person)
    {
        CmdSyncHealth(h, person);
    }


    [Command]
    void CmdSyncHealth(float h, GameObject person)
    {
        RpcSyncHealth(h, person);
    }

    [ClientRpc]
    void RpcSyncHealth(float h, GameObject person)
    {
        MMove hitmove = person.GetComponent(typeof(MMove)) as MMove;
        hitmove.myHealth = h;
        StartCoroutine(hitmove.Flash());
        print(hitmove.myHealth);
        if (hasAuthority)
        {
            otherGuys.text = hitmove.myHealth.ToString();
        }
        else
        {
            hitmove.mine.text = hitmove.myHealth.ToString();
            src.PlayOneShot(Damaged);
        }
    }



    [Command]
    void CmdUpdatePos(Vector2 pos, Vector2 scale)
    {
        RpcUpdatePos(pos, scale);
    }

    [ClientRpc]
    void RpcUpdatePos(Vector2 pos, Vector2 scale)
    {
        if (hasAuthority) { return; }
        transform.position = pos;
        transform.localScale = scale;
    }

    [Client]
    void FixedUpdate()
    {
        if (finished) { return; }
        if (myHealth <= 0)
        {
            sr.enabled = false;
            finished = true;
        }
        if (!hasAuthority)
        {
            try
            {
                Destroy(rb);
            }
            catch
            {

            }
            return;
        }
        CmdSyncCat(PlayerPrefs.GetString("currentCat"));
        xmov = Input.GetAxisRaw("Horizontal");


        if (xmov > 0)
        {
            tf.position = new Vector2(transform.position.x + (vel / 100), transform.position.y + 1 / 100);
            tf.localScale = new Vector2(1f, 1f);
        }

        if (xmov < 0)
        {
            tf.position = new Vector2(transform.position.x - (vel / 100), transform.position.y + 1 / 100);
            tf.localScale = new Vector2(-1f, 1f);
        }
        CmdUpdatePos(transform.position, transform.localScale);

        CmdUpdateBullet(mbuc.transform.position, mbuc.transform.localScale);
    }


    IEnumerator Flash()
    {
        sr.color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(0.55f);
        sr.color = new Color(255, 255, 255, 255);
    }


    [Command]
    void CmdUpdateBullet(Vector2 pos, Vector2 scale)
    {
        RpcUpdateBullet(pos, scale);
    }

    [ClientRpc]
    void RpcUpdateBullet(Vector2 pos, Vector2 scale)
    {
        if (hasAuthority) { return; }
        mbuc.transform.position = pos;
        mbuc.transform.localScale = scale;
    }

    void Update()
    {
        if (myHealth <= 0)
        {
            if (hasAuthority)
            {
                Lose.SetActive(true);
            }
            else
            {
                Win.SetActive(true);
            }
        }
    }



}
