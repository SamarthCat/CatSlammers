using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    public string mapno;
    public bool canget;


    void Start()
    {

    }

    public void win(int amount)
    {

        PlayerPrefs.SetInt("dataCoins", PlayerPrefs.GetInt("dataCoins") + amount);
        PlayerPrefs.SetString(mapno, "yes");
        canget = false;
       
    }


    void Update()
    {
        if (PlayerPrefs.GetString(mapno) == "yes")
        {
            canget = false;
        }
        else if (PlayerPrefs.GetString(mapno) != "yes")
        {
            canget = true;

        }
    }
}
