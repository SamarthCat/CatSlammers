using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockController : MonoBehaviour
{
    public Image img;
    public Sprite light;
    public Sprite dark;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int THEisNight = PlayerPrefs.GetInt("nightData");


        if (THEisNight == 0)
        {
            img.sprite = dark;
        }
        else if (THEisNight == 1)
        {
            img.sprite = light;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
