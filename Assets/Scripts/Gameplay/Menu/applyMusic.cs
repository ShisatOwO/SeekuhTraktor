using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyMusic : MonoBehaviour
{
    public GameObject AudioObj;
    private dontDestroy AudioScript;

    void Start() {
    	AudioObj =  GameObject.FindGameObjectWithTag("AudioTag");
    	AudioScript = AudioObj.GetComponent<dontDestroy>();

    }

    public void startPlaying() {
    	AudioScript.StartAudio();
    }
    
}
