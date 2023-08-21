using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using Dialog;

public class EveryoneSavesTheDay : TextLine
{
    public TextLine nextLineII;
    public GameObject Main;
    public GameObject lives;
    private bool dsoo = true;
    private bool dsoo2 = false;
    private int _start = 0;
    public GameObject TextBox;
    public GameObject TextBoxII;
    public GameObject BoundEndController;
    public GameObject RaketenTraktor;
    public GameObject rightLeg;
    private float _seekuhBarrier;

    private int frameBarr = 0;

    // Start is called before the first frame update
    public override void speak()
    {
        _start += 1;
        TextBox.SetActive(false);
        TextBoxII.SetActive(false);
        if(_start == 2) {
            BoundEndController.GetComponent<BoundEndController>().ActivateEnd();
            RaketenTraktor.gameObject.GetComponent<PlayerRocket>().movementAllowed = false;
            PlayerPrefs.SetInt("ScoreSceneOverdub", Main.GetComponent<Vars>().scoreInt);
            PlayerPrefs.SetInt("Lives", lives.GetComponent<live_handler>().getLives());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _seekuhBarrier = RaketenTraktor.gameObject.transform.position.x -3;
        if(_start == 1 && gameObject.transform.position.x <= _seekuhBarrier) {
            gameObject.transform.position += new Vector3 (0.1f,0,0);
        }

        if(dsoo && _start == 1 && gameObject.transform.position.x > _seekuhBarrier) {
            TextBoxII.SetActive(true);
            dsoo = false;
        }


        if(_start == 2) {
            RotateLeg();
            if(dsoo2){
                RaketenTraktor.gameObject.transform.position += new Vector3(0,0.1f,0);
            }
            if(RaketenTraktor.gameObject.transform.position.y >= 8) {
                GameObject.Find("BackgroundMusic").GetComponent<dontDestroy>().BackToGame();
                SceneManager.LoadScene("SkyNew"); 
            }
        }
    }

    void RotateLeg() {
        
        rightLeg.gameObject.transform.Rotate(new Vector3(0,0,1));
        if(frameBarr >= 30) {
            dsoo2 = true;
        } else {
            frameBarr += 1;
        }

    }


}
