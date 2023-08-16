using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{

    public bool normalGame;

    public GameObject scoreObj;
    private Score scoreScript;
    private ScoreMediaMark scoreScriptM;

    public GameObject mobileUI;

	public int scoreInt = 0;


    public GameObject[] everyEnemyArray;

    
    public bool[] isEnemyOnScreen = new bool[20];
    public string[] everyEnemyStringArr;

	public bool zugOnS = false;
    public bool amphOnS = false;



    public bool justJumped;
    public AudioClip[] jumpClips;
    private int clipArrayIndex;
    private AudioSource audioSrcMain;
    // Start is called before the first frame update
    void Start()
    {
        if (normalGame) scoreScript = scoreObj.GetComponent<Score>();
        if (!normalGame) scoreScriptM = scoreObj.GetComponent<ScoreMediaMark>();
        if(GetComponent<AudioSource>() != null) { audioSrcMain = GetComponent<AudioSource>(); }
        Debug.Log("scoreInt" + scoreInt);

        if(PlayerPrefs.GetInt("mobile") == 1) {
            mobileUI.SetActive(false);
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (normalGame) scoreInt = scoreScript.score;
        if (!normalGame) scoreInt = scoreScriptM.score;
        if(justJumped && normalGame) {
            justJumped = false;
            PlaySound();
        }
        
        
    }

    void PlaySound() {

        clipArrayIndex = Random.Range(0,jumpClips.Length);
        //Debug.Log(clipArrayIndex);
        audioSrcMain.Stop();
        audioSrcMain.clip = jumpClips[clipArrayIndex];
        audioSrcMain.Play();


    }
}
