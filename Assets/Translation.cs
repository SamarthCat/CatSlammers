using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Translation : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public string[] English;
    public string[] French;
    public string[] Romanian;

    void Awake()
    {
        tmp = GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        if (PlayerPrefs.GetString("lang") == "En" | string.IsNullOrEmpty(PlayerPrefs.GetString("lang")))
        {
            return;
        }
        StartCoroutine(SetLang());
    }

    IEnumerator SetLang()
    {
        while (true)
        {
            for (int i = 0; i < English.Length; i++)
            {
                if (PlayerPrefs.GetString("lang") == "Fr")
                {
                    if (tmp.text.Contains(English[i]))
                    {  
                        tmp.text = tmp.text.Replace(English[i], French[i]);
                    }
                }
                else if (PlayerPrefs.GetString("lang") == "Ro")
                {
                    if (tmp.text.Contains(English[i]))
                    {
                        tmp.text = tmp.text.Replace(English[i], Romanian[i]);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
