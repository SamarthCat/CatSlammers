using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{
    public HighScores hs;
    bool isChild = true;
    public GameObject displayInfo;
    public GameObject[] Infos;
    TextMeshProUGUI tmp1;
    TextMeshProUGUI tmp2;
    public float lastPos = 15;
    public RectTransform currentRT;

    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(HighScores)) as HighScores;
    }


    public void MakeCDisplay()
    {
        StartCoroutine(CDisplay());
    }

    IEnumerator CDisplay()
    {
        for (int i = 0; i < Infos.Length; i++)
        {
            Destroy(Infos[i]);
            lastPos = 15;
        }

        for (int i = 0; i < hs.highscoresList.Length; i++)
        {
            Infos[i] = Instantiate(displayInfo);
            Infos[i].transform.SetParent(gameObject.transform);
            currentRT = Infos[i].GetComponent(typeof(RectTransform)) as RectTransform;
            currentRT.anchoredPosition = new Vector3(0, lastPos - 15, 0);
            Infos[i].transform.localScale = new Vector3(1, 1, 1);
            //Complicated Way To Get Text, PlayerText has an Audio Source and Score Text has RigidBody2D
            tmp1 = Infos[i].GetComponentInChildren(typeof(AudioSource)).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            tmp2 = Infos[i].GetComponentInChildren(typeof(Rigidbody2D)).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;

            tmp1.text = (i + 1) + ". " + hs.highscoresList[i].username;
            tmp2.text = hs.highscoresList[i].score + " Cat Coins";
            if (hs.highscoresList[i].username.Equals(PlayerPrefs.GetString("username")))
            {
                tmp1.text = (i + 1) + ". " + hs.highscoresList[i].username + "(You)";
            }

            lastPos = currentRT.anchoredPosition.y;
        }

        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
