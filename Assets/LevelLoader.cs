using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Resolution[] resolutions;
    public int currentResolutionIndex;
    public string[] optionHeight = {""};
    bool fs;

    private void Awake()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
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

        if (options[PlayerPrefs.GetInt("res")].Contains("Fullscreen"))
        {
            //Debug.Log("Changed Res To index: " + options[PlayerPrefs.GetInt("res")] + " and Is Fullscreen");
            fs = true;
        }
        else
        {
            //Debug.Log("Changed Res To index: " + options[PlayerPrefs.GetInt("res")] + " and Is NOT Fullscreen");
            fs = false;
        }
        string[] _option = options[PlayerPrefs.GetInt("res")].Split('x');
        if (_option[1].Contains("Fullscreen"))
        {
            optionHeight = _option[1].Split('(');
        }
        else
        {
            optionHeight[0] = _option[1];
        }
        int width = int.Parse(_option[0]);
        int height = int.Parse(optionHeight[0]);
        Screen.SetResolution(width, height, fs);
    }

    public Animator an;
    public Image loader;
    public void Load(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(string scene)
    {
        an.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }


    void FixedUpdate()
    {
        var euler = loader.transform.eulerAngles;
        euler.z -= 1.8f;
        loader.transform.eulerAngles = euler;
    }
}
