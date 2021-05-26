using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalMenu : MonoBehaviour
{
	public GameObject trans;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseDown() {
    	Toggle();
	 }

    void Toggle()
        {
        	if(trans.active == true) {
            	trans.SetActive(false);
            	Debug.Log("normMenu is off");
        	}
        	if(trans.active == false) {
            	trans.SetActive(true);
        	}

        }
}
