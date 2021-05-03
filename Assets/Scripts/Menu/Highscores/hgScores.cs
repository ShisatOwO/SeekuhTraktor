using UnityEngine;
using System.Collections;

public class hgScores : MonoBehaviour {

	const string privateCode = "iCS1qBjNs0CGanSPUKy9BAwel91EY91EaywYkdykd-ZQ";
	const string publicCode = "6055c6188f40bbaf006fd3f0";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	static hgScores instance;
	public string nname;
	public GameObject nscore;
	public TMPro.TextMeshProUGUI tmproNscore;
	public string nscoreString;
	public int nscoreInt;

	
	void Awake() {

		nscore = this.gameObject.transform.GetChild (0).gameObject;
		tmproNscore = nscore.GetComponent<TMPro.TextMeshProUGUI>();
		nscoreString = tmproNscore.text;
		int.TryParse(nscoreString, out nscoreInt);
		Debug.Log(nscoreInt);
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		instance = this;
	}

	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			print ("Upload Successful");
			DownloadHighscores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}