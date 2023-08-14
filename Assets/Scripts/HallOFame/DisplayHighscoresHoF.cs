using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscoresHoF : MonoBehaviour {

    public GameObject[] hgScoresGO;
    public TMPro.TextMeshPro[] highscoreFields;
    public TMPro.TextMeshPro[] highscoreFieldsNames;
    hgScoresHoF highscoresManager;
    public Highscore[] highscoreListSpeicher;
    public GameObject NameNScore;
    private GameObject[] _canvas;

    void Start() {
        for (int i = 0; i < hgScoresGO.Length; i ++) {
            hgScoresGO[i] = Instantiate(NameNScore, new Vector3(30,-i,0), Quaternion.identity);
            //_canvas[i] = hgScoresGO[i].transform.GetChild(0).gameObject;
            
            highscoreFields[i] = hgScoresGO[i].transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshPro>();
            highscoreFieldsNames[i] = hgScoresGO[i].transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshPro>();

            if(i+1 <= 9) {
                highscoreFieldsNames[i].text = "0" + i+1 + ". Fetching...";
            } else {
                highscoreFieldsNames[i].text = i+1 + ". Fetching...";
            }
        }

        print("started");
 
        highscoresManager = GetComponent<hgScoresHoF>();
        StartCoroutine("RefreshHighscores");
    }
    
    public void OnHighscoresDownloaded(Highscore[] highscoreList) {
        print("downloaded");
        highscoreListSpeicher = highscoreList;
        for (int i = 0; i < highscoreFields.Length; i ++) {

            if(i+1 <= 9) {
                highscoreFieldsNames[i].text = "0" + (i+1) + ".";
            } else {
                highscoreFieldsNames[i].text = i+1 + ".";
            }
            //highscoreFieldsNames[i].text = i+1 + ". ";

            if (i < highscoreList.Length) {
                highscoreFieldsNames[i].text +=  "         " + highscoreList[i].score + "      ";
                highscoreFields[i].text = highscoreList[i].username;

                // + highscoreList[i].username;
            }
        }
    }

    public void changePage(int cPage) {

        for (int i =0; i < highscoreFields.Length; i ++) {
            highscoreFields[i].text = i+1+(cPage*9) + ". ";
            if (i < highscoreListSpeicher.Length) {
                highscoreFields[i].text +=  "         " + highscoreListSpeicher[i+(9*cPage)].score + "      ";
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