using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenParent : MonoBehaviour
{
	public GameObject genRight;
	private GenRight genRightScript;
	public GameObject genLeft;
	private GenRight genLeftScript;
    public GameObject genUp;
    private GenRight genUpScript;
    public GameObject genDown;
    private GenRight genDownScript;


	public int direction;
	public int countFrames;
	public int frameBorder;
	private bool testSpawn = false;


	public GameObject mainObj;
	private Vars mainVars;
	public int grense = 5;

	public int repetT = 150;
	private int randoT;

    // Start is called before the first frame update
    void Start()
    {
    	genRightScript = genRight.GetComponent<GenRight>();
    	genLeftScript = genLeft.GetComponent<GenRight>();
        genUpScript = genUp.GetComponent<GenRight>();
        genDownScript = genDown.GetComponent<GenRight>();

        mainVars = mainObj.GetComponent<Vars>();

        direction = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {

    	

    	

    	TestIfSpawn(mainVars.scoreInt);
    	//Debug.Log("direct= " + direction);

    	//debug
    	//direction = 4;
    	//debug
    	if(mainVars.scoreInt > 10000) {
        	testSpawn = false;
        }
        if(mainVars.scoreInt > 10100) {
        	genRightScript.spawnMeteor();
        }


    	if(direction == 1 && testSpawn == true) {
    		genRightScript.spawn();
    		testSpawn = false;
    		countFrames = 0;
    	} else if(direction == 2 && testSpawn == true) {
    		genLeftScript.spawn();
    		testSpawn = false;
    		countFrames = 0;
    	} else if(direction == 3 && testSpawn == true) {
            genUpScript.spawn();
            testSpawn = false;
            countFrames = 0;
        } else if(direction == 4 && testSpawn == true) {
            genDownScript.spawn();
            testSpawn = false;
            countFrames = 0;
        }



    	countFrames++;

        
    }

    public void TestIfSpawn(int sco) {
    	if(countFrames >= frameBorder) {
    		randoT = Random.Range(-30, 31);

       		frameBorder = randoT + repetT - (mainVars.scoreInt / 11) + 850;
        	//Debug.Log(frameBorder);
    		testSpawn = true;
    		direction = Random.Range(1, 5);
    	}

    }
}
