using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject lsc;
    public GameObject csc;
    public LevelSelector ll;
    public TextMeshProUGUI tmp;
    AudioSource As;


    public void Awake()
    {

        As = GameObject.FindGameObjectWithTag("Audio").GetComponent(typeof(AudioSource)) as AudioSource; 

        if (PlayerPrefs.GetString("done1") == "yes")
        {
           As.enabled = true;

            if (PlayerPrefs.GetString("do2") == "yes")
            {
                tmp.text = "Back To The Present";
                StartCoroutine(cs());
                PlayerPrefs.SetString("do2", "no");
            }
        }
        else
        {
            StartCoroutine(cs());
        }
    }

      
    

    IEnumerator cs()
    {
        yield return null;
        As.enabled = false;
        lsc.SetActive(false);
        csc.SetActive(true);
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetString("done1", "yes");
        PlayerPrefs.SetString("do2", "no");
        ll.Other();
    }
}
