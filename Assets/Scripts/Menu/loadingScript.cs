using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingScript : MonoBehaviour
{
	public int countFrames;
    public SceneSwitcher sceneSwitch;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("VolumeSlider", 1f);
        PlayerPrefs.SetInt("AudioSrc", 0);
    }

    // Update is called once per frame
    void Update()
    {
        countFrames++;
        if(countFrames >= 100) {
        	sceneSwitch.toSceneMenu();
        }
    }
}
