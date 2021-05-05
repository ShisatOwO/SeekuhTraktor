using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPackager : MonoBehaviour
{
	///public SkyEnemyRight esr;

    // Start is called before the first frame update
    void Start()
    {
        /*
    	//Left
        if(transform.position.x < -6 && transform.position.y < 5 && transform.position.y > -5) {
        	gameObject.AddComponent<SkyEnemyLeft>();
        }

        //Right
        if(transform.position.x > 6 && transform.position.y < 5 && transform.position.y > -5) {
        	gameObject.AddComponent<SkyEnemyRight>();
        }

        //Down
        if(transform.position.y < -4 && transform.position.x < 8 && transform.position.y > -8) {
        	gameObject.AddComponent<SkyEnemyDown>();
        }

        //Up
        if(transform.position.y > 4 && transform.position.x < 8 && transform.position.y > -8) {
        	gameObject.AddComponent<SkyEnemyUp>();
        }
        */

        //Left
        if(transform.position.x < -6) {
            gameObject.AddComponent<SkyEnemyLeft>();
        }

        //Right
        if(transform.position.x > 6) {
            gameObject.AddComponent<SkyEnemyRight>();
        }

        //Down
        if(transform.position.y < -4) {
            gameObject.AddComponent<SkyEnemyDown>();
        }

        //Up
        if(transform.position.y > 4) {
            gameObject.AddComponent<SkyEnemyUp>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
