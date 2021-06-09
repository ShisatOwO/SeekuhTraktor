using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{
    public GameObject scoreObj;
    private Score scoreScript;

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
        scoreScript = scoreObj.GetComponent<Score>();
        audioSrcMain = GetComponent<AudioSource>();
        Debug.Log("scoreInt" + scoreInt);
        if(PlayerPrefs.GetInt("mobile") == 1) {
            mobileUI.SetActive(false);
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        scoreInt = scoreScript.score;
        if(justJumped) {
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
