
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

	public TMPro.TextMeshProUGUI[] highscoreFields;
	public TMPro.TextMeshProUGUI[] highscoreFieldsNames;
	hgScores highscoresManager;
	public Highscore[] highscoreListSpeicher;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}

				
		highscoresManager = GetComponent<hgScores>();
		StartCoroutine("RefreshHighscores");
	}
	
	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		highscoreListSpeicher = highscoreList;
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text +=  " 	      " + highscoreList[i].score + "      ";
				highscoreFieldsNames[i].text = highscoreList[i].username;

				// + highscoreList[i].username;
			}
		}
	}

	public void changePage(int cPage) {

		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1+(cPage*9) + ". ";
			if (i < highscoreListSpeicher.Length) {
				highscoreFields[i].text +=  " 	      " + highscoreListSpeicher[i+(9*cPage)].score + "      ";
				highscoreFieldsNames[i].text = highscoreListSpeicher[i+(9*cPage)].username;

				// + highscoreList[i].username;
			}
		}
	}
	
	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}