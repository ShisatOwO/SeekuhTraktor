using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomYPos : MonoBehaviour
{
	public float ypos1;
	public float ypos2;
	public float ypos3;
	private int chooseYPos;
	public float variance;
	private int countFrames;
    // Start is called before the first frame update
    void Start()
    {
    	ypos1 = 4f;
    	ypos2 = 0f;
    	ypos3 = -4f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	countFrames++;
    	if(countFrames >= 50) {
    		var();
    		decidePos();
    	}
        
    }

    void var() {
    	variance = Random.Range(-50, 51);
        variance = variance / 100;
       // Debug.Log(variance);
    }
    void decidePos() {
    	chooseYPos = Random.Range(1, 4);
    	if(chooseYPos == 1) {
    		transform.position = new Vector3 (transform.position.x, ypos1 + variance, transform.position.z);
    	} else if(chooseYPos == 2) {
    		transform.position = new Vector3 (transform.position.x, ypos2 + variance, transform.position.z);
    	} else if(chooseYPos == 3) {
    		transform.position = new Vector3 (transform.position.x, ypos3 + variance, transform.position.z);
    	}
    }
}
