using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    // Show FPS Vars
    public Toggle FPStg;

    // No SceneTransition Vars
    //public Toggle transtg;

    void Start()
    {
        //if (PlayerPrefs.GetInt("noTrans") == 1)
        //{
            //transtg.isOn = true;
        //}
        //else
        //{
            //transtg.isOn = false;
        //}

        if (PlayerPrefs.GetInt("showFps") == 1)
        {
            FPStg.isOn = true;
        }
        else
        {
            FPStg.isOn = false;
        }
    }

    public void ChangeFpsDisplay()
    {
        if (PlayerPrefs.GetInt("showFps") == 1)
        {
            PlayerPrefs.SetInt("showFps", 0);
            FPStg.isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("showFps", 1);
            FPStg.isOn = true;
        }
    }

    public void Toggleface(bool booly)
    {
        if (booly)
        {
            PlayerPrefs.SetInt("showFps", 1);
        }
        else
        {
            PlayerPrefs.SetInt("showFps", 0);
        }
    }

    public void ChangeTransDisplay()
    {
        if (PlayerPrefs.GetInt("noTrans") == 1)
        {
            PlayerPrefs.SetInt("noTrans", 0);
            //transtg.isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("noTrans", 1);
            //transtg.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
