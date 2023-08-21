using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSetup : MonoBehaviour
{
    private dontDestroy bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("BackgroundMusic").GetComponent<dontDestroy>().BackToGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
