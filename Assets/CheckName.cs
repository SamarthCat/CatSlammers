using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckName : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public TMP_InputField tmpi;
    public ExampleColorReceiver ecr;
    public UIPopUp uip;
    public TextMeshProUGUI signIn;
    public TextMeshProUGUI tmpitext;

    void Start()
    {
        ecr.Hide();
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("email")))
        {
            signIn.text = "Signed In :)";
            tmpi.interactable = false;
            tmpi.text = PlayerPrefs.GetString("email").Substring(0, PlayerPrefs.GetString("email").IndexOf("@"));
            tmpitext.color = new Color(0, 0, 0, 0.3f);
        }
        else
        {
            signIn.text = "Sign In";
            tmpi.interactable = true;
            tmpi.text = "";
        }
    }

    IEnumerator Flash(string msg)
    {
        tmp.color = new Color(255, 0, 0, 255);
        tmp.text = msg;
        tmp.fontSize = 60;
        yield return new WaitForSeconds(3);
        tmp.color = Color.white;
        tmp.text = "Meow!";
        tmp.fontSize = 101.8f;
    }

    public void Button()
    {
        // If there is less than 4 chars
        if (tmpi.text.Length <= 3)
        {
            StartCoroutine(Flash("Min 4 Chars!"));
        }

        // If there is more than 16 chars
        else if (tmpi.text.Length > 16)
        {
            StartCoroutine(Flash("Max 16 Chars!"));
        }

        // If there is Asterisk
        else if (tmpi.text.Contains("*"))
        {
            StartCoroutine(Flash("No Asterisks!"));
        }

        // If colour is black
        else if (PlayerPrefs.GetString("Colour") == "0_0_0_")
        {
            StartCoroutine(Flash("Your Fav Colour Can't Be Black"));
        }

        //Submit
        else
        {
            PlayerPrefs.SetString("username", tmpi.text);
            uip.funcshow();
            //SceneManager.LoadScene("Title");
        }
    }




    void Update()
    {
        
    }
}
