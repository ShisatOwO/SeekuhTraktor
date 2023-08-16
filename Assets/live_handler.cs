using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class live_handler : MonoBehaviour
{
    private Vars _vars;
    
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;

    public bool loadLivesFromPlayerPrefs;

    public bool invulnarability;

    void Start() {
        _vars = GameObject.Find("Main").GetComponent<Vars>();
        if(loadLivesFromPlayerPrefs) {
            loadLives(PlayerPrefs.GetInt("Lives"));
        }
        
    }
    public void removeLive() {
        if(!invulnarability) {
            if (!live3.activeSelf) {
                if (!live2.activeSelf) {
                    
                    PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                    SceneManager.LoadScene("HighscoreAfterGame");

                    /*if (!live1.activeSelf) {

                    } else {
                        live1.SetActive(false);
                    }*/
                } else {
                    live2.SetActive(false);
                }
            } else {
                live3.SetActive(false);
            }
        }
    }


    public void addLive() {
        if (!live2.activeSelf) {
            live2.SetActive(true);
        } else if (!live3.activeSelf) {
            live3.SetActive(true);
        } 
    }

    public int getLives() {
        if (!live1.activeSelf) {
            return 0;
        } else if (!live2.activeSelf) {
            return 1;
        } else if (!live1.activeSelf) {
            return 2;
        } else {
            return 3;
        }
    }

    public void saveLives() {
        PlayerPrefs.SetInt("Lives", getLives());
    }

    public void loadLives(int l) {
        switch(l) 
        {
            case 1:
                live1.SetActive(true);
                live2.SetActive(false);
                live3.SetActive(false);
                break;

            case 2:
                live1.SetActive(true);
                live2.SetActive(true);
                live3.SetActive(false);
                break;

            case 3:
                live1.SetActive(true);
                live2.SetActive(true);
                live3.SetActive(true);
                break;
        }
    }

}
