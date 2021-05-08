using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGenScript : MonoBehaviour
{
	private int countFram;
	public GameObject eGan;
	private GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countFram++;
        if(countFram >= 100) {
        	s();
        	countFram = 0;
        }
        
    }

    void s() {
    	Spawn = Instantiate(eGan, transform.position, Quaternion.identity) as GameObject;
    }
}
