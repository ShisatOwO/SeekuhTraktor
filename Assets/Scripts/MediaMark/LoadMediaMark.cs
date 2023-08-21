using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMediaMark : MonoBehaviour
{
    private dontDestroy _AudioScript;
    private GameObject bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GameObject.Find("BackgroundMusic");
        if(bgMusic != null) {
            _AudioScript = bgMusic.GetComponent<dontDestroy>();
            _AudioScript.BossMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



//bg Music leiser