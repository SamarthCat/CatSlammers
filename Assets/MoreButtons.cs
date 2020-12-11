using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoreButtons : MonoBehaviour
{
    bool fs;
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public int currentResolutionIndex;
    public string[] optionHeight;
    List<string> options = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        currentResolutionIndex = PlayerPrefs.GetInt("res");
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            string optionfs = resolutions[i].width + "x" + resolutions[i].height + "(Fullscreen)";
            options.Add(option);
            options.Add(optionfs);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("res");
        resolutionDropdown.RefreshShownValue();

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void SetResolution(int index)
    {
        //Debug.Log(resolutionDropdown.captionText.text);
        if (resolutionDropdown.captionText.text.Contains("Fullscreen"))
        {
            fs = true;
            //Debug.Log("Changed Res To index: " + index + " and Is Fullscreen");
        }
        else
        {
            fs = false;
            //Debug.Log("Changed Res To index: " + index + " and Is NOT Fullscreen");
        }
        string[] option = options[index].Split('x');
        if (option[1].Contains("Fullscreen"))
        {
            optionHeight = option[1].Split('(');
        }
        else
        {
            optionHeight[0] = option[1];
        }
        int width = int.Parse(option[0]);
        int height = int.Parse(optionHeight[0]);
        PlayerPrefs.SetInt("res", index);
        Screen.SetResolution(width, height, fs);
    }



}
