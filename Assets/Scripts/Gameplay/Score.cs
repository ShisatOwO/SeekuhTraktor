using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score = 0;
	public Text scText;
    public bool sky = false;

    // Start is called before the first frame update
    void Start()
    {
        if(sky == true) {
            score = PlayerPrefs.GetInt("ScoreSceneOverdub");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
    	GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    	score++;
    }
}
