using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderListener : MonoBehaviour
{
	public GameObject audioObj;
	private AudioSource audioS;
	public Slider slide;

	
    // Start is called before the first frame update
    void Awake()
    {
    	//slide = GetComponent<Slider>();
        audioObj = GameObject.FindWithTag("AudioTag");
        audioS = audioObj.GetComponent<AudioSource>();
        audioS.volume = PlayerPrefs.GetFloat("VolumeSlider");
        Debug.Log(PlayerPrefs.GetFloat("VolumeSlider"));
        slide.value = PlayerPrefs.GetFloat("VolumeSlider");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderHandler(float va) {
    	Debug.Log(va);
    	audioS.volume = va;
    	PlayerPrefs.SetFloat("VolumeSlider", va);
    }
}
