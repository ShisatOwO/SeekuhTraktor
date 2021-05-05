using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyEnemyRight : MonoBehaviour
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
    public Transform trans;

    private Rigidbody2D rigidb;


    public GameObject scoSpedObject;
    public Score scoSpeedScript;
    private int scoreCounterCa;

    private Vector3 normKnoTransScale;
   // public GameObject scoSpedObject;
   // public Score scoSpeedScript;
    // Start is called before the first frame update
    void Awake()
    {  
    	mainObj = GameObject.FindWithTag("Main");
    	mainVars = mainObj.GetComponent<Vars>();
    	trans = GetComponent<Transform>();
        scoSpedObject = GameObject.Find("CanSky/ScoreTMP");
        scoSpeedScript = scoSpedObject.GetComponent<Score>();
        rigidb = GetComponent<Rigidbody2D>();
        if(loff == true) {
            transform.Rotate (new Vector3 (0, 0, -75.817f));
            transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);

        }

        if(kno == true) {
            normKnoTransScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) + new Vector3 (Random.Range(-1f,2f), Random.Range(-1,2), 0f);
            if(normKnoTransScale.x == 0f || normKnoTransScale.y == 0f) {
                normKnoTransScale.x = 1.1f;
                normKnoTransScale.y = 0.9f;
            }
            transform.localScale = normKnoTransScale;
            Debug.Log("normKnoTransScale" + normKnoTransScale);

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
        scoreCounterCa = mainVars.scoreInt;
        this.rigidb.velocity += new Vector2((-1 * scoreCounterCa / 800),0f);

        
    }

    void FixedUpdate() {

        
    }

    // Update is called once per frame
    void Update()
    {

     //   scoreSped = 1 / 10000;
    	
        //transform.position = transform.position + new Vector3 ((((-1*sped) + (-1 * scoreCounterCa / 800)) * Time.deltaTime),0f,0f);
        
        //trans.position = trans.position + new Vector3 (((-1*sped) * Time.deltaTime),0f,0f);
        //Debug.Log("Speed" + (((-1*sped) + (-1 *scoreCounterCa / 800)) * Time.deltaTime));
        
        if(rot == true) {
            transform.Rotate (new Vector3 (0, 0, rotSped) * Time.deltaTime);
        }   

        if(transform.position.x >= 15) {
            Destroy(transform.gameObject);
        }
        if(transform.position.x <= -15) {
            Destroy(transform.gameObject);
        }
        if(transform.position.y >= 10) {
            Destroy(transform.gameObject);
        }
        if(transform.position.y <= -10) {
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
            SceneManager.LoadScene("SkyAnim"); 
        }
    }
}
