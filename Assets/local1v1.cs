using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class local1v1 : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Rigidbody2D rigidBody2;
    public float vel = 5;
    public GameObject Player2;
    private Transform tf;
    private Transform tf2;
    public AudioSource asrc;
    public AudioClip jumpclip;
    public AudioClip beeclip;
    public AudioClip shootclip;
    public BulletController1v1 p1c;
    public BulletController1v1 p2c;
    public int p1h = 10;
    public int p2h = 10;
    public Transform Player1HealthBar;
    public Transform Player2HealthBar;
    public GameObject winScreen;
    public GameObject p1win;
    public GameObject p2win;
    public GameObject jb;
    public Image pnl;
    bool done = false;
    public AudioClip win;

    public Animator po;
    public Animator sp1;
    public Animator sp2;

    void Start()
    {
        tf = transform;
        rigidBody = GetComponent<Rigidbody2D>();
        tf2 = Player2.transform;
        rigidBody2 = Player2.GetComponent<Rigidbody2D>();
    }

    public void bullethit(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            //Player 1 was hit
            p1h -= 1;
        }
        else if (col.gameObject.name == "Player2")
        {
            //Player 2 was hit
            p2h -= 1;
        }
    }

    IEnumerator Win(GameObject pwin)
    {
        if (!done)
        {
            jb.SetActive(true);
            var cnvs = winScreen.GetComponent(typeof(Canvas)) as Canvas;
            cnvs.targetDisplay = 4;
            winScreen.SetActive(true);
            po.SetBool("po", true);
            sp1.SetBool("sp1", true);
            sp2.SetBool("sp2", true);
            yield return new WaitForSeconds(0.99f);
            cnvs.targetDisplay = 0;
            pwin.SetActive(true);
            yield return new WaitForSeconds(6.3f);
            asrc.PlayOneShot(win);
            //Time.timeScale = 0f;
        }
    }


    void FixedUpdate()
    {
        Player2HealthBar.localScale = new Vector2(p2h / 10f, Player2HealthBar.localScale.y);
        Player1HealthBar.localScale = new Vector2(p1h / 10f, Player1HealthBar.localScale.y);

        if (p1h <= 0)
        {
            //Player 1 is dead
            StartCoroutine(Win(p2win));
            done = true;
        }

        if (p2h <= 0)
        {
            //Player 2 is dead
            StartCoroutine(Win(p1win));
            done = true;
        }


        //Player 1 Controls
        if (Input.GetKey(KeyCode.D))
        {
            tf.position = new Vector2(transform.position.x + (vel / 100), transform.position.y + 1 / 100);
            tf.localScale = new Vector2(1f, tf.localScale.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tf.position = new Vector2(transform.position.x - (vel / 100), transform.position.y + 1 / 100);
            tf.localScale = new Vector2(-1f, tf.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 8);
            asrc.PlayOneShot(jumpclip, 1f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            p1c.fire();
        }

        //Player 2 Controls
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf2.position = new Vector2(tf2.position.x + (vel / 100), tf2.position.y + 1 / 100);
            tf2.localScale = new Vector2(1f, tf2.localScale.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf2.position = new Vector2(tf2.position.x - (vel / 100), tf2.position.y + 1 / 100);
            tf2.localScale = new Vector2(-1f, tf2.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidBody2.velocity = new Vector2(rigidBody2.velocity.x, 8);
            asrc.PlayOneShot(jumpclip, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            p2c.fire();
        }
    }
}
