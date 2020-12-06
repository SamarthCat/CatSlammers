using System;
using System.Collections.Specialized;
using System.Net;
using UnityEngine;


public class dWebHook : MonoBehaviour, IDisposable
{
    private readonly WebClient dWebClient;
    private static NameValueCollection discordValues = new NameValueCollection();


    public string key = null;


    public dWebHook()
    {
        dWebClient = new WebClient();
    }


    public void SendMessage(string msg, string user)
    {
        discordValues.Clear();
        discordValues.Add("username", user);
        discordValues.Add("content", msg);

        dWebClient.UploadValues(key, discordValues);
    }

    public void Dispose()
    {
        dWebClient.Dispose();
    }
}