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
    GUIStyle style;

    private void Awake()
    {
        //FPS Controller starts here
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 44;
        style.normal.textColor = new Color32(0, 0, 0, 255);
        //FPS Controller ends here
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

        if (PlayerPrefs.GetInt("noTrans") != 1)
        {
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene(scene);
    }


    void FixedUpdate()
    {
        var euler = loader.transform.eulerAngles;
        euler.z -= 1.8f;
        loader.transform.eulerAngles = euler;
    }

    //FPS Controller starts here

    private string _fpsText;
    private float _hudRefreshRate = 0.01f;
    private float _timer;

    private void Update()
    {
        if (PlayerPrefs.GetInt("showFps") != 1) { return; }
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText = fps + "FPS";
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }

    void OnGUI()
    {
        if (PlayerPrefs.GetInt("showFps") != 1) { return; }
        int width = Screen.width;
        int height = Screen.height;
        Rect rect = new Rect(200, 0, width - 200, height * 2 / 100);

        UnityEngine.GUI.Label(rect, _fpsText, style);
    }
}
