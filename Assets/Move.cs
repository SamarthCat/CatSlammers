using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;



public class Move : MonoBehaviour
{
    [SerializeField]
    public float vel = 5;
    [SerializeField]
    public Transform tf;
    public SpriteRenderer sr;
    public SpriteRenderer bsr;
    public Sprite cat1;
    public Sprite cat1bullet;
    public Sprite cat2;
    public Sprite cat2bullet;
    public Sprite cat3;
    public Sprite cat3bullet;
    public Sprite cat4;
    public Sprite cat4bullet;
    public Sprite cat4_1;
    public Sprite cat4_1bullet;
    public Sprite cat5;
    public Sprite cat5bullet;
    public Sprite cat6;
    public Sprite cat6bullet;
    public Sprite cat7;
    public Sprite cat7bullet;
    public Sprite cat8;
    public Sprite cat8bullet;
    public Sprite cat8_1;
    public Sprite cat8_1bullet;
    public Sprite cat9;
    public Sprite cat9bullet;
    public Sprite cat10;
    public Sprite cat10bullet;
    public Sprite cat11;
    public Sprite cat11bullet;
    public Sprite cat12;
    public Sprite cat12bullet;
    public Sprite cat13;
    public Sprite cat13bullet;
    public Sprite cat14;
    public Sprite cat14bullet;
    public Sprite cat15;
    public Sprite cat15bullet;
    public Sprite cat16;
    public Sprite cat16bullet;

    void Awake()
    {

	if (String.IsNullOrEmpty(PlayerPrefs.GetString("username")))
        {
            SceneManager.LoadScene("TitleUser");
        }

	if (String.IsNullOrEmpty(PlayerPrefs.GetString("currentMusic")))
        {
            PlayerPrefs.SetString("currentMusic", "Music1");
        }

        sr = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetString("currentCat") == "cat1")
        {
            sr.sprite = cat1;
            bsr.sprite = cat1bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat2")
        {
            sr.sprite = cat2;
            bsr.sprite = cat2bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat3")
        {
            sr.sprite = cat3;
            bsr.sprite = cat3bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat4")
        {
            sr.sprite = cat4;
            bsr.sprite = cat4bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat4.1")
        {
            cat4_1 = Resources.Load<Sprite>("cat4.1");
            cat4_1bullet = Resources.Load<Sprite>("PizzaCutter");
            sr.sprite = cat4_1;
            bsr.sprite = cat4_1bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat5")
        {
            sr.sprite = cat5;
            bsr.sprite = cat5bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat6")
        {
            sr.sprite = cat6;
            bsr.sprite = cat6bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat7")
        {
            sr.sprite = cat7;
            bsr.sprite = cat7bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat8")
        {
            sr.sprite = cat8;
            bsr.sprite = cat8bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat8.1")
        {
            cat8_1 = Resources.Load<Sprite>("cat8.1");
            cat8_1bullet = Resources.Load<Sprite>("Iron Bar");
            sr.sprite = cat8_1;
            bsr.sprite = cat8_1bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat9")
        {
            sr.sprite = cat9;
            bsr.sprite = cat9bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat10")
        {
            sr.sprite = cat10;
            bsr.sprite = cat10bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat11")
        {
            sr.sprite = cat11;
            bsr.sprite = cat11bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat12")
        {
            sr.sprite = cat12;
            bsr.sprite = cat12bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat13")
        {
            sr.sprite = cat13;
            bsr.sprite = cat13bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat14")
        {
            sr.sprite = cat14;
            bsr.sprite = cat14bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat15")
        {
            sr.sprite = cat15;
            bsr.sprite = cat15bullet;
        }
        else if (PlayerPrefs.GetString("currentCat") == "cat16")
        {
            cat16 = Resources.Load<Sprite>("cat16");
            cat16bullet = Resources.Load<Sprite>("Ruby Bar");
            sr.sprite = cat16;
            bsr.sprite = cat16bullet;
        }
    }

    void FixedUpdate()
    {

        float xmov = Input.GetAxisRaw("Horizontal");

        if (xmov > 0)
        {
            tf.position = new Vector2(transform.position.x + (vel / 100) , transform.position.y + 1/100);
            tf.localScale = new Vector2(1f, tf.localScale.y);
        }

        if (xmov < 0)
        {
            tf.position = new Vector2(transform.position.x - (vel / 100), transform.position.y + 1 / 100);
            tf.localScale = new Vector2(-1f, tf.localScale.y);
       }


    }
}
