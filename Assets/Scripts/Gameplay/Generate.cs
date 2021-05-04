using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Generate : MonoBehaviour
{
	public GameObject Spawn;
	public GameObject eIQ;
    public GameObject eMik;
    public GameObject eGan;
    public GameObject eLof;
    public GameObject eTot;
    public GameObject eCrou;
    public GameObject eKno;
    public GameObject eBoss;
    public GameObject eAuto;
    public GameObject eMohr;
    public GameObject eLamp;
    public GameObject eZug;
    public GameObject rocket;


    public GameObject mainObj;
    private Vars mainVars;

    public bool dSpawn = false;
    public bool debugSpawn = false;
    public int debugInt = 0;

    public bool bossS = false;
    public bool bossRn = false;

	private float repet;
    public float repetT;
    private int countFrames;
    private int grenzeBevor = 7;
    private int grenze = 7;

    public GameObject scoSpedObject;
    public Score scoSpeedScript;
    private float scoreSped = 1f;
    private int score;

    private int rando = 0;
    private int randoT = 0;
    // Start is called before the first frame update
    void Start()
    {

        mainVars = mainObj.GetComponent<Vars>();
    	
        scoSpeedScript = scoSpedObject.GetComponent<Score>();
        r();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mainVars.zugOnS == true) {
           dSpawn = true;
           debugInt = 8;
        } else {
            dSpawn = false;
        }
    	//Which one spawns??
    	rando = Random.Range(1, grenze + 1);
        score = scoSpeedScript.score;
       // Debug.Log("SCore=" + score);

    	//count Frames
    	countFrames++;
        

        if(bossRn == false) {
            if(countFrames >= repet) {
            	countFrames = 0;
            	a();
            	r();
            }
        }

        
        if(score >= 3000 ) {
           // bossS = true;
            grenze = 10;
            grenzeBevor = 10;
        }

        if(score >= 4000 ) {
           // bossS = true;
            grenze = 12;
            grenzeBevor = 12;
        }

        if(score >= 6000) {
            debugSpawn = true;
            dSpawn = true;
            debugInt = 1000;
        }

        if(score >= 6300) {
            Spawn  = Instantiate (rocket,transform.position,Quaternion.identity)as GameObject;
            Destroy(this);
        }
/*
/*
        if(bossS == true && bossRn == false) {
            bSpawn();
        }
        if(bossRn == true) {
            bSpawn();
        }
        //Debug.Log(scoreSped);
*/      
        
    }

    void a() {

    	if(debugSpawn == true || dSpawn == true) {
    		rando = debugInt;
    	}

        if(mainVars.amphOnS == true && rando == 12) {
            rando = 1;
            Debug.Log("KeinZugHeute");
        }

        if(mainVars.amphOnS == true && rando == 6) {
            rando = 2;
            Debug.Log("KeinZugHeute2");
        }

        Debug.Log("Rando=" + rando);

        if(rando == 1) {
    	    Spawn  = Instantiate (eIQ,transform.position,Quaternion.identity)as GameObject;
        } else if(rando == 2) {
            Spawn  = Instantiate (eMik,transform.position,Quaternion.identity)as GameObject;
        } else if(rando == 3) {
            Spawn  = Instantiate (eGan,transform.position,Quaternion.identity)as GameObject;
        } else if(rando == 4) {
            Spawn  = Instantiate (eCrou,transform.position,Quaternion.identity)as GameObject;
        } else if(rando == 5) {
            Spawn  = Instantiate (eTot,transform.position,Quaternion.identity)as GameObject;
        } else if(rando == 6) {
            Spawn  = Instantiate (eLof,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 8) {
        	Spawn  = Instantiate (eKno,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 7) {
            Spawn  = Instantiate (eMohr,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 10) {
            Spawn  = Instantiate (eBoss,new Vector3(10f, 4.3f, 0f),Quaternion.identity)as GameObject;
        } else if (rando == 11) {
            Spawn  = Instantiate (eAuto,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 9) {
            Spawn  = Instantiate (eLamp,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 12) {
            Spawn  = Instantiate (eZug,transform.position,Quaternion.identity)as GameObject;
        }

    }

   /* void bSpawn() {
         Spawn  = Instantiate (eBoss,new Vector3(10f, 4.3f, 0f),Quaternion.identity)as GameObject;

    }*/

    void r() {
    	randoT = Random.Range(-30, 31);
    	scoreSped = scoSpeedScript.score;
        repet = randoT + repetT - (scoreSped / 30) + 100;
        Debug.Log(repet);
    }
}
