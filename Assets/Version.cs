using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Version : MonoBehaviour
{
    public string currentVersion;
    public TextMeshProUGUI tmp;
    public Color Red;
    public Color Green;
    public Color Orange;
    bool annoyed = false;

    void Start()
    {
        tmp.text = currentVersion;
    }

    void Update()
    {
        if (PlayerPrefs.GetString("webVersion") == "")
        {
            tmp.color = Orange;
        }
        else if (PlayerPrefs.GetString("webVersion") != currentVersion)
        {
            tmp.color = Red;
            if (!annoyed)
            {
                StartCoroutine(annoy());
            }
        }
        else
        {
            tmp.color = Green;
        }
    }

    IEnumerator annoy()
    {
        annoyed = true;
        while (true)
        {
            tmp.text = currentVersion;
            yield return new WaitForSeconds(2);
            tmp.text = "Out Of Date";
            yield return new WaitForSeconds(2);
            tmp.text = "Update Now";
            yield return new WaitForSeconds(2);
        }
    }
}
