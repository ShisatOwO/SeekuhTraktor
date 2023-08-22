using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalSubmitButton : MonoBehaviour
{
	//const string privateCode = "iCS1qBjNs0CGanSPUKy9BAwel91EY91EaywYkdykd-ZQ";
	//const string publicCode = "6055c6188f40bbaf006fd3f0";
	const string privateCode = "7RWsjAmiQECpZdFm4rhbYgT9M4lA0jl0yTIR2MkcQv3g";
	const string publicCode = "64da0a458f40bb0ee052d1c9";
	const string webURL = "http://dreamlo.com/lb/";
	static finalSubmitButton instance;

	public GameObject inputHandlerObj;
	public TMPro.TextMeshProUGUI inp;
	public string sname;
	public int sscore;


    // Start is called before the first frame update
    void Awake()
    {

        inp = inputHandlerObj.GetComponent<TMPro.TextMeshProUGUI>();
        instance = this;
    }

    void Update()
    {
    	sname = inp.text;
        //print("This is it: " + inp.text.Length);

    }

    public void SubmitFinal() {

    sscore = PlayerPrefs.GetInt("ScoreSceneOverdub");
    //sscore = 9000;
    	if(inp.text.Length == 1) {
    		sname = "GeheimTraktor007";
    		Debug.Log("isNullOrEmpty");
    	}
    	AdddNewHighscore(sname,sscore);
    }



    public static void AdddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UpploadNewHighscore(username,score));
	}

	IEnumerator UpploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			Debug.Log("Upload Successful");
			
		}
		else {
			Debug.Log("Error uploading: " + www.error);
		}
	}
}
