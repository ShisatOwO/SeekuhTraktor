using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class RocketAnim : MonoBehaviour
{
	public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
    	trans = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	trans.position += new Vector3(transform.position.x, 0.1f, transform.position.z);
    	if(trans.position.y >= 14) {
    		SceneManager.LoadScene("Sky"); 
    	}
        
    }
}
