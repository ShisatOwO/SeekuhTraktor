using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public AudioClip standard;
	public AudioClip cursed;
	public AudioClip pianoIntensifies;
	public bool loopAudio = true;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if(PlayerPrefs.GetInt("AudioSrc") == 0) {
    		audio.clip = standard;
    	}
    	if(PlayerPrefs.GetInt("AudioSrc") == 1) {
    		audio.clip = cursed;
    	}
    	if(PlayerPrefs.GetInt("AudioSrc") == 2) {
    		audio.clip = pianoIntensifies;
    	}




        DontDestroyOnLoad(this.gameObject);
        audio.Play();
        

    }

    void Update() {
    	if(PlayerPrefs.GetInt("AudioSrc") == 0) {
    		GetComponent<AudioSource>().clip = standard;
    	}
    	if(PlayerPrefs.GetInt("AudioSrc") == 1) {
    		GetComponent<AudioSource>().clip = cursed;
    	}
    	if(PlayerPrefs.GetInt("AudioSrc") == 2) {
    		GetComponent<AudioSource>().clip = pianoIntensifies;
    	}



    }

    public void StartAudio() {
    	GetComponent<AudioSource>().Play();
    }
}
