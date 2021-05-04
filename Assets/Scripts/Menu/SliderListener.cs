using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderListener : MonoBehaviour
{
	public GameObject audioObj;
	private AudioSource audioS;
	
    // Start is called before the first frame update
    void Start()
    {
        audioObj = GameObject.FindWithTag("AudioTag");
        audioS = audioObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderHandler(float value) {
    	Debug.Log(value);
    	audioS.volume = value;
    }
}
