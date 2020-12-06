using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PPManager : MonoBehaviour
{
    public bool disabler;
    public bool isToggle;
    public PostProcessVolume pp;
    public Toggle tg;

    void Start()
    {

        if (isToggle)
        {
            if (PlayerPrefs.GetInt("noPost") == 1)
            {
                tg.isOn = false;
            }
            else
            {
                tg.isOn = true;
            }
        }
    }

    public void Toggleface(bool booly)
    {
        if (booly)
        {
            PlayerPrefs.SetInt("noPost", 0);
        }
        else
        {
            PlayerPrefs.SetInt("noPost", 1);
        }
    }

    void Update()
    {

        if (PlayerPrefs.GetInt("noPost") == 1 && disabler)
        {
            pp.enabled = false;
        }
        else if (PlayerPrefs.GetInt("noPost") != 1 && disabler)
        {
            pp.enabled = true;
        }

    }
}
