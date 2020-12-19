using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class mbc : NetworkBehaviour
{

    
    public float PHealth = 10;
    public float EHealth = 10;
    public Transform tf;
    public Transform etf;
    public EnemyAI eai;
    public SpriteRenderer sr;
    public SpriteRenderer esr;
    public GetMoney gm;
    public int putback;
    public int eputback;
    public ParticleSystem eps;
    public CircleCollider2D ec;
    public bool isAlive = true;
    public bool eisAlive = true;
    public AIPath path;
    public AudioSource audio;
    public AudioClip beeclip;
    public AudioClip jumpclip;
    public AudioClip shootclip;
    public AudioClip explodeclip;
    public AudioClip pclip;
    public AudioClip bossmusic;
    public GameObject gameoverui;
    public GameObject winoverui;
    public GameObject Player1;
    public GameObject Player2;
    public PauseMenu pm;
    public float PDamage;
    public int amountToWin;
    public TextMeshProUGUI tmp;
    public float Ediv = 10;
    public string[] iplist;


    [Server]
    void Start()
    {
        eps.Stop();
    }

    public void CollideEnemy(Collision2D col)
    {

        if (col.gameObject.name == "Enemy")
        {
            PHealth = PHealth - eai.enemyDamage;
            flash();

        }
    }




    public void bullethit()
    {
        EHealth = EHealth - PDamage;
        eflash();
    }

    void flash()
    {
        sr.color = new Color(0, 0, 0);
        audio.PlayOneShot(pclip, 1f);
    }   

    void eflash()
    {
        //esr.color = new Color(0, 0, 0);
        audio.PlayOneShot(beeclip, 1f);
    }


        
        void Update()
    {
        if (eisAlive)
        {
            tf.localScale = new Vector2(PHealth / 10, tf.localScale.y);
            etf.localScale = new Vector2(EHealth / Ediv, etf.localScale.y);
        }

        if (putback == 30)
        {
            sr.color = new Color(255, 255, 255);
            putback = 0;
        }

        if (sr.color.r == 0f)
        {
            putback = putback + 1;
        }




        if (eputback == 30)
        {
            //esr.color = new Color(255, 255, 255);
            eputback = 0;
        }

        //if (esr.color.r == 0f)
        //{
        //    eputback = eputback + 1;
        //}



        if (PHealth <= 0f & isAlive)
        {

            pm.es2.enabled = false;
            pm.es.enabled = true;
            pm.es3.enabled = false;
            gameoverui.SetActive(true);
            isAlive = false;
            Time.timeScale = 0f;
        }

        if (EHealth <= 0f & eisAlive)
        {
            pm.es2.enabled = false;
            pm.es.enabled = false;
            pm.es3.enabled = true;
            audio.PlayOneShot(explodeclip, 1f);
            eps.Play();
            //esr.enabled = false;
            ec.enabled = false;
            eisAlive = false;
            path.enabled = false;
            winoverui.SetActive(true);
            etf.localScale = new Vector2(0, etf.localScale.y);
            if (gm.canget)
            {
                tmp.text = "You Earned " + amountToWin + " Cat Coins";
                gm.win(amountToWin);
            }
            else
            {
                tmp.text = "You Already Played This Level";
            }
        }


    }
}
