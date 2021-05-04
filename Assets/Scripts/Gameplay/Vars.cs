using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{
    public GameObject scoreObj;
    private Score scoreScript;

	public int scoreInt = 0;


	public bool zugOnS = false;
    public bool amphOnS = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = scoreObj.GetComponent<Score>();
        Debug.Log("scoreInt" + scoreInt);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreInt = scoreScript.score;

        
    }
}
