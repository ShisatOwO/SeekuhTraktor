using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Enemy : MonoBehaviour
{
	public float sped = 6f;
    public bool rot = false;
    public bool loff = false;
    public float rotSped = 1f;
    private float scoreSped = 0f;
    public bool kno = false;
    public bool seem = false;
    public bool lamp = false;
    public bool zug = false;
    public bool crou = false;
    public bool rocket = false;


    public GameObject mainObj;
    private Vars mainVars;


    public GameObject scoSpedObject;
    public Score scoSpeedScript;
    private int scoreCounterCa;


   // public GameObject scoSpedObject;
   // public Score scoSpeedScript;
    // Start is called before the first frame update
    void Awake()
    {  
    	mainObj = GameObject.FindWithTag("Main");
    	mainVars = mainObj.GetComponent<Vars>();
        scoSpedObject = GameObject.Find("Canvas/ScoreTMP");
        scoSpeedScript = scoSpedObject.GetComponent<Score>();
        if(loff == true) {
            transform.Rotate (new Vector3 (0, 0, -75.817f));
            transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);

        }

        if(kno == true) {
            transform.position = new Vector3(transform.position.x, -1.3f, transform.position.z);
        }

        if(lamp == true) {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }

        if(seem == true) {
            transform.position = new Vector3(transform.position.x, 0.62f, transform.position.z);
            transform.Rotate (new Vector3 (0, 0, 48.195f));
        }
        if(zug == true) {
        	transform.position = new Vector3(42.5f, -1.87f, transform.position.z);
        }
        if(rocket == true) {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        
    }

    void FixedUpdate() {
        scoreCounterCa = scoSpeedScript.score;
    }

    // Update is called once per frame
    void Update()
    {

     //   scoreSped = 1 / 10000;
    
        transform.position = transform.position + new Vector3 ((((-1*sped) + (-1 * scoreCounterCa / 800)) * Time.deltaTime),0f,0f);
        //Debug.Log("Speed" + (((-1*sped) + (-1 *scoreCounterCa / 800)) * Time.deltaTime));
        
        if(rot == true) {
            transform.Rotate (new Vector3 (0, 0, rotSped) * Time.deltaTime);
        }   
        if(transform.position.x <= -30) {
            Destroy(transform.gameObject);
        }
        if(zug == true) {
        	if(transform.position.x >= -7.62) {
        		mainVars.zugOnS = true;
        	} else {mainVars.zugOnS = false;}
        }


    }


    private void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Player" && crou == true) {
            Destroy(transform.gameObject);
        }
        if (otherObj.gameObject.tag == "Player" && rocket == true) {
            PlayerPrefs.SetInt("hihscore", scoSpeedScript.score);
            SceneManager.LoadScene("SkyAnim"); 
        }
    }
}
