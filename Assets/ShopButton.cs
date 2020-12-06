﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{


    public float damage;
    public string cat;
    public Button Buy;
    public Button Equip;
    public int price;
    public TextMeshProUGUI ownership;
    public TextMeshProUGUI equiptext;

    void Start()
    {

    }

    void Update()
    {
        //if you dont have it
        if (PlayerPrefs.GetInt(cat) == 0)
        {
            Equip.interactable = false;
            //if you can afford it
            if (PlayerPrefs.GetInt("dataCoins") >= price)
            {
                Buy.interactable = true;
            }
            else
            {
                Buy.interactable = false;
            }
            ownership.text = price.ToString() + " Cat Coins";
        }
        else
        {
            Buy.interactable = false;
            Equip.interactable = true;
            ownership.text = "Owned";
            if (PlayerPrefs.GetString("currentCat") == cat)
            {
                equiptext.text = "Equipped";
            }
            else
            {
                equiptext.text = "Equip";
            }
        }

    }

    public void buy()
    {
        PlayerPrefs.SetInt(cat, 1);
        PlayerPrefs.SetInt("dataCoins", PlayerPrefs.GetInt("dataCoins") - price);
        
    }

    public void equip()
    {
        PlayerPrefs.SetString("currentCat", cat);
        PlayerPrefs.SetFloat("Damage", damage);
    }

}
