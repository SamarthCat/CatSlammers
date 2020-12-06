using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoreButtons : MonoBehaviour
{
    public bool isToggle;
    public Toggle tg;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public int currentResolutionIndex;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        currentResolutionIndex = PlayerPrefs.GetInt("res");
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("res");
        resolutionDropdown.RefreshShownValue();

        if (isToggle)
        {
            if (PlayerPrefs.GetInt("Fullscreen") == 1)
            {
                tg.isOn = false;
            }
            else
            {
                tg.isOn = true;
            }
        }
    }


    public void Fullscreen(bool booly)
    {
        if (booly)
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {



        if (PlayerPrefs.GetInt("Fullscreen") == 1)
        {
            Screen.fullScreen = false;
        }
        else if (PlayerPrefs.GetInt("Fullscreen") != 1)
        {
            Screen.fullScreen = true;
        }
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        PlayerPrefs.SetInt("res", index);
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }



}
