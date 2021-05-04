using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{

	public GameObject nscore;
	private Score scoreScript;
	public static int scoreIntLoader;



    // Start is called before the first frame update
    void Awake()
    {
    	scoreScript = nscore.GetComponent<Score>();
       // DontDestroyOnLoad(this.gameObject);
      
    }

    // Update is called once per frame
    void Update()
    {
    	scoreIntLoader = scoreScript.score;
    	//Debug.Log(scoreIntLoader);
        
    }
}
