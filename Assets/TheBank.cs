using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheBank : MonoBehaviour
{

    public TextMeshProUGUI tmp;

    void Awake()
    {
        
    }

    public void add(int number)
    {
        PlayerPrefs.SetInt("dataCoins", number);
    }


    void Update()
    {
        tmp.text = PlayerPrefs.GetInt("dataCoins").ToString();
    }
}
