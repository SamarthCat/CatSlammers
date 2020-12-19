using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxManager : MonoBehaviour
{
    public bool isXbox;
    public GameObject[] xboxOnly;

    void Start()
    {
        if (isXbox)
        {
            PlayerPrefs.SetInt("isXbox", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isXbox", 0);
        }

        for (int i = 0; i < xboxOnly.Length; i++)
        {
            if (isXbox)
            {
                xboxOnly[i].SetActive(true);
            }
            else
            {
                xboxOnly[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
