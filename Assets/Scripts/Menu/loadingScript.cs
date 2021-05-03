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
