using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRight : MonoBehaviour
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
    public GameObject eMeteor;




    public GameObject mainObj;
    private Vars mainVars;

    public GameObject scoSpedObject;
    public Score scoSpeedScript;
    private float scoreSped = 1f;
    private int score;
    public int grenze = 3;

    private int rando = 0;


    // Start is called before the first frame update
    void Start()
    {
        mainObj = GameObject.FindWithTag("Main");
        mainVars = mainObj.GetComponent<Vars>();
        scoSpeedScript = scoSpedObject.GetComponent<Score>();

        
    }

   

    public void spawn() {

        rando = Random.Range(1, 5);
        //rando = 3;

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
        } else if (rando == 7) {
        	Spawn  = Instantiate (eKno,transform.position,Quaternion.identity)as GameObject;
        } else if (rando == 8) {
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

    public void spawnMeteor() {
        Spawn  = Instantiate (eMeteor,transform.position,Quaternion.identity)as GameObject;
    }
}

