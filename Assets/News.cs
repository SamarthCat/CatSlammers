using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class News : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer img;
    public string url = "http://catslammers.netlify.app/news.png";
    public string url2 = "http://catslammers.netlify.app/info.txt";
    public string VDL;

    void Start()
    {
        StartCoroutine(GetTexture());
        StartCoroutine(GetVersion());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D newsDL = ((DownloadHandlerTexture)www.downloadHandler).texture;
            img.sprite = Sprite.Create(newsDL, new Rect(0, 0, newsDL.width, newsDL.height), new Vector2(0.5f, 0.5f));
        }
    }

    IEnumerator GetVersion()
    {
        WWW www = new WWW(url2);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);

        }
        else
        {
            VDL = www.text;
            PlayerPrefs.SetString("webVersion", VDL);
        }
    }


}