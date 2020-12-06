using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{

	const string privateCode = "lnvAUSktkEG-o50tmwMggAW9I2xqj1OEe4UWvwMkw3nQ";
	const string publicCode = "5f81341feb371809c4746c26";
	const string webURL = "http://dreamlo.com/lb/";
	public DisplayScores ds;
	public GameObject NoInternet;
	public GameObject go;
	public bool Offline = false;

	public Highscore[] highscoresList;

	void Awake()
	{

        try
        {
			ds = GameObject.FindGameObjectWithTag("Stick").GetComponent(typeof(DisplayScores)) as DisplayScores;
		}
        catch
        {

        }

		if (Ping(webURL + privateCode))
        {
			print("U ONLINE FACE FACE");
			StartCoroutine(UpdateLB());
			if (SceneManager.GetActiveScene().name == "Leaderboard")
			{
				DownloadHighscores();
			}
		}
		else if (SceneManager.GetActiveScene().name == "Leaderboard")
		{
			//Say that i'm offline;
			NoInternet.SetActive(true);
			Destroy(go);
			enabled = false;
		}

	}


    void Update()
    {
		if (Offline && SceneManager.GetActiveScene().name != "Leaderboard")
		{
			//Say that i'm offline;
			NoInternet.SetActive(true);
			Destroy(go);
			enabled = false;
		}
	}

    IEnumerator UpdateLB()
    {
		while (true)
        {
			if (SceneManager.GetActiveScene().name != "Leaderboard" && PlayerPrefs.GetInt("NoLB") == 0)
			{
				//DownloadHighscores();
				yield return new WaitForSeconds(5);
				AddNewHighscore(PlayerPrefs.GetString("username"), PlayerPrefs.GetInt("dataCoins"));
			}
			else if (SceneManager.GetActiveScene().name == "Leaderboard")
            {
				DownloadHighscores();
            }
			else if (PlayerPrefs.GetInt("NoLB") == 1)
			{
				yield return null;
			}
			else if (SceneManager.GetActiveScene().name != "Leaderboard")
			{
				yield return new WaitForSeconds(5);
				AddNewHighscore(PlayerPrefs.GetString("username"), PlayerPrefs.GetInt("dataCoins"));
			}
			yield return new WaitForSeconds(5);

		}		
    }


	public bool Ping(string url)
    {
		WWW ThingToPing = new WWW(url);





		if (string.IsNullOrEmpty(ThingToPing.error))
		{
			return true;
		}
		else
		{
			print("THER IS EROR");
			return false;
		}


    }


	public void AddNewHighscore(string username, int score)
	{
		StartCoroutine(DeleteMyScore(username, score));
		StartCoroutine(UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
        {
			//print("Upload Successful");
		}
		else
		{
			Debug.LogError("Error uploading: " + www.error);
			Offline = true;
		}
	}

	IEnumerator DeleteMyScore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/delete/" + WWW.EscapeURL(username));
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			//print("Deletion Successful");
		}
		else
		{
			Debug.LogError("Error Removing: " + www.error);
			Offline = true;
		}
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			FormatHighscores(www.text);
		else
		{
			Debug.LogError("Error Downloading: " + www.error);
			Offline = true;

		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			//print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
		ds.MakeCDisplay();
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}
}