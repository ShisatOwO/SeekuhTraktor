using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomXPos : MonoBehaviour
{
    public float xpos1;
	public float xpos2;
	public float xpos3;
	private int chooseXPos;
	public float variance;
	private int countFrames;
    // Start is called before the first frame update
    void Start()
    {
    	xpos1 = 7f;
    	xpos2 = 0f;
    	xpos3 = -7f;
        
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
        //Debug.Log(variance);
    }
    void decidePos() {
    	chooseXPos = Random.Range(1, 4);
    	if(chooseXPos == 1) {
    		transform.position = new Vector3 (xpos1 + variance, transform.position.y, transform.position.z);
    	} else if(chooseXPos == 2) {
    		transform.position = new Vector3 (xpos2 + variance, transform.position.y, transform.position.z);
    	} else if(chooseXPos == 3) {
    		transform.position = new Vector3 (xpos3 + variance, transform.position.y, transform.position.z);
    	}
    }
}
