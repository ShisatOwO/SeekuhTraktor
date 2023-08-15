using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMediaMark : MonoBehaviour
{

    public int score = 6000;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("ScoreSceneOverdub");
    }
    

    void FixedUpdate() {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    }
}
