using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefSky : MonoBehaviour
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
    }

    void Update()
    {
        
    }
}
