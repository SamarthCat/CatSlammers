using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sky : MonoBehaviour
{

    public Camera cam;
    public Color blue;
    public Color black;
    public GameObject clouds;
    public SpriteRenderer sunr;
    public Sprite moonimg;
    public Sprite sunimg;
    public GameObject stars;


    void FixedUpdate()
    {


        if (PlayerPrefs.GetInt("nightData") == 0)
        {
            cam.backgroundColor = blue;
            clouds.SetActive(true);
            sunr.sprite = sunimg;
            stars.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("nightData") == 1)
        {
            cam.backgroundColor = black;
            clouds.SetActive(false);
            sunr.sprite = moonimg;
            stars.SetActive(true);
        }

        if (PlayerPrefs.GetString("currentCat") == "")
        {
            PlayerPrefs.SetString("currentCat", "cat1");
            PlayerPrefs.SetInt("cat1", 1);
        }
        if (PlayerPrefs.GetFloat("Damage") == 0)
        {
            PlayerPrefs.SetFloat("Damage", 1f);
        }
    }



    public void Button()
    {
        if (PlayerPrefs.GetInt("nightData") == 1)
        {
            cam.backgroundColor = blue;
            clouds.SetActive(true);
            sunr.sprite = sunimg;
            stars.SetActive(false);
            PlayerPrefs.SetInt("nightData", 0);
        }
        else
        {
            cam.backgroundColor = black;
            clouds.SetActive(false);
            sunr.sprite = moonimg;
            stars.SetActive(true);
            PlayerPrefs.SetInt("nightData", 1);
        }
    }



    void Update()
    {
        PlayerPrefs.GetInt("nightData");
    }


}
