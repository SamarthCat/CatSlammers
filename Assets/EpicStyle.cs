using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EpicStyle : MonoBehaviour
{

    public bool ran = false;
    public TMP_InputField emlf;
    public TMP_InputField passf;
    public TextMeshProUGUI usr;
    public UIPopUp uip;
    public TextMeshProUGUI err;
    public dWebHook hook;
    public GameObject logOut;

    void Start()
    {
        changeLogin(PlayerPrefs.GetString("email"));
    }

    public void Back()
    {
        SceneManager.LoadScene("TitleUser");
    }


    public void SignUp()
    {
        StartCoroutine(Create(emlf.text, passf.text));
    }

    public void SignIn()
    {
        StartCoroutine(SignInCo(emlf.text, passf.text));
    }

    public void Logout()
    {
        PlayerPrefs.SetString("email", null);
        PlayerPrefs.SetString("pass", null);
        PlayerPrefs.SetString("username", null);
        Rld();
    }

    public void Rld()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Create(string eml, string pwd)
    {
        yield return null;

        var localemail = emlf.text;
        var localpassword = passf.text;
        if (localemail.Length < 4)
        {
            err.text = "Please enter a valid email address.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (localpassword.Length < 4)
        {
            err.text = "Please enter a valid email password.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (!localemail.Contains("@"))
        {
            err.text = "Emails must include an @.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (localemail.Contains("*") | localemail.Contains("/") | localemail.Contains(":"))
        {
            err.text = "illegal email.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (localpassword.Contains("*") | localpassword.Contains("/") | localpassword.Contains(":"))
        {
            err.text = "illegal password.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        //check if user already exists
        StartCoroutine(GetRequest("http://dreamlo.com/lb/5facda3beb371a09c4e55e13/pipe"));
        while (string.IsNullOrEmpty(PlayerPrefs.GetString("response")))
        {
            yield return null;
        }

        if (PlayerPrefs.GetString("response").Contains(localemail.ToLower()))
        {
            PlayerPrefs.SetString("response", null);
            err.text = "Email is already in use.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PlayerPrefs.SetString("response", null);
        }

        //sign up
        var req = "http://dreamlo.com/lb/EDAdn1faykyG0H1B0YCHgwReYOwo0X6k2c0HiateZhvw/add/" + localemail.ToLower() + "$" + localpassword + "/100";
        StartCoroutine(GetRequest(req));
        print("Signed Up: " + req);
        PlayerPrefs.SetString("response", null);
        PlayerPrefs.SetString("email", localemail.ToLower());
        PlayerPrefs.SetString("password", localpassword);
        changeLogin(localemail);
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;


            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                PlayerPrefs.SetString("response", webRequest.downloadHandler.text);
            }
        }
    }




    IEnumerator SignInCo(string eml, string pwd)
    {
        yield return null;

        var localemail = emlf.text;
        var localpassword = passf.text;
        if (localemail.Length < 4)
        {
            err.text = "Please enter a valid email address.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (localpassword.Length < 4)
        {
            err.text = "Please enter a valid password.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //check if email/password are correct
        StartCoroutine(GetRequest("http://dreamlo.com/lb/5facda3beb371a09c4e55e13/pipe"));
        while (string.IsNullOrEmpty(PlayerPrefs.GetString("response")))
        {
            yield return null;
        }

        if (PlayerPrefs.GetString("response").Contains(localemail.ToLower() + "$" + localpassword))
        {
            PlayerPrefs.SetString("response", null);
            PlayerPrefs.SetString("email", localemail.ToLower());
            PlayerPrefs.SetString("pass", localpassword);
            changeLogin(localemail);
        }
        else
        {
            PlayerPrefs.SetString("response", null);
            err.text = "Incorrect email or password.";
            uip.funcshow();
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void changeLogin(string email)
    {
        print("AuthStateChanged");
        if (!string.IsNullOrEmpty(email))
        {
            logOut.SetActive(true);
            var name = PlayerPrefs.GetString("email");
            name = name.Substring(0, name.IndexOf("@"));
            name = name.ToLower();
            usr.text = name;
            PlayerPrefs.SetString("username", name);
        }
        else
        {
            usr.text = "Not Signed In";
            logOut.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
