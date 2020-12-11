using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Encourage : MonoBehaviour
{
    public string[] encourage;
    public string[] discourage;
    TextMeshProUGUI tmp;
    public Animation an;
    public Color Orange;
    bool isRunning = false;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        //doEncourage();
    }

    

    public void doEncourage()
    {
        tmp.color = new Color(255, 255, 255);
        var rand = Random.Range(0,encourage.Length);
        tmp.text = encourage[rand];
        an.Play();
    }

    public void doCritical()
    {
        tmp.color = Orange;
        tmp.text = "CRITICAL HIT!";
        StartCoroutine(FlashSky(Orange));
        an.Play();
    }

    public void doDiscourage()
    {
        tmp.color = new Color(255, 0, 0);
        var rand = Random.Range(0, discourage.Length);
        tmp.text = discourage[rand];
        an.Play();
    }
    
    IEnumerator FlashSky(Color colour)
    {
        if (!isRunning)
        {
            isRunning = true;
            var oldColour = Camera.main.backgroundColor;
            Camera.main.backgroundColor = colour;
            yield return new WaitForSeconds(1.3f);
            Camera.main.backgroundColor = oldColour;
            isRunning = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            doEncourage();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            doCritical();
        }

    }
}
