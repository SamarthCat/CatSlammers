using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicShopButton : MonoBehaviour
{
    public Button Buy;
    public Button Equip;

    public string PlayerPrefsTitle;

    public int price;
    public TextMeshProUGUI ownerShip;
    public TextMeshProUGUI equipText;

    public AudioClip Music;

    private AudioSource asrc;
    private AudioSource mainSrc;
    private bool prlocked;

    void Awake()
    {
        asrc = gameObject.AddComponent<AudioSource>();
        try
        {
            mainSrc = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        }
        catch
        {
            mainSrc = null;
        }
    }

    public void PreviewButton()
    {
        if (prlocked) { return; }
        prlocked = true;
        StartCoroutine(Preview());
    }

    IEnumerator Preview()
    {
        try
        {
            mainSrc.volume = 0f;
        }
        catch
        {

        }
        asrc.PlayOneShot(Music);
        yield return new WaitForSeconds(Music.length);
        mainSrc.volume = 0.268f;
        prlocked = false;
    }

    public void BuyButton()
    {
        //if you can afford it
        if (PlayerPrefs.GetInt("dataCoins") >= price)
        {
            PlayerPrefs.SetInt(PlayerPrefsTitle, 1);
            PlayerPrefs.SetInt("dataCoins", PlayerPrefs.GetInt("dataCoins") - price);
        }
    }

    public void EquipButton()
    {
        if (PlayerPrefs.GetString("currentMusic") == PlayerPrefsTitle) { return; }
        //if owned
        if (PlayerPrefs.GetInt(PlayerPrefsTitle) == 1)
        {
            PlayerPrefs.SetString("currentMusic", PlayerPrefsTitle);
            mainSrc.gameObject.GetComponent<DontDestroy>().play();
        }
    }

    void FixedUpdate()
    {
        //if owned
        if (PlayerPrefs.GetInt(PlayerPrefsTitle) == 1)
        {
            ownerShip.text = "Owned";
            Equip.interactable = true;
            Buy.interactable = false;
            //if equipped
            if (PlayerPrefs.GetString("currentMusic") == PlayerPrefsTitle)
            {
                equipText.text = "Equipped";
            }
            else
            {
                equipText.text = "Equip";
            }

        }
        else
        {
            ownerShip.text = price + " Cat Coins";
            Equip.interactable = false;
            equipText.text = "Equip";
            //if you can afford it
            if (PlayerPrefs.GetInt("dataCoins") >= price)
            {
                Buy.interactable = true;
            }
        }
    }

    private void OnDestroy()
    {
        //Destroy(mainSrc.gameObject);
    }
}
