using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public bool startAudio = true;
    public AudioClip standard;
	public AudioClip cursed;
	public AudioClip pianoIntensifies;
    public AudioClip bronto;
    public AudioClip cowbell;
    public AudioClip boss_music_clip;
    public AudioClip bongo;
	public bool loopAudio = true;

    private bool _bossMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if(PlayerPrefs.GetInt("AudioSrc") == 0) {
            GetComponent<AudioSource>().clip = standard;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 1) {
            GetComponent<AudioSource>().clip = cursed;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 2) {
            GetComponent<AudioSource>().clip = pianoIntensifies;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 3) {
            GetComponent<AudioSource>().clip = cowbell;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 4) {
            GetComponent<AudioSource>().clip = bronto;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 5) {
            GetComponent<AudioSource>().clip = bongo;
        }




        DontDestroyOnLoad(this.gameObject);
        if(startAudio) audio.Play();

        if (Application.platform == RuntimePlatform.Android)
        {
            PlayerPrefs.SetInt("mobile", 0);
        } else {
            PlayerPrefs.SetInt("mobile", 1);
        }

        PlayerPrefs.SetInt("ScoreSceneOverdub", 0);
        
        

    }

    public void BossMusic() {
        GetComponent<AudioSource>().clip = boss_music_clip;
        _bossMusic = true;
        //GetComponent<AudioSource>().Play();
    }

    public void BackToGame() {
        _bossMusic = false;
        if(PlayerPrefs.GetInt("AudioSrc") == 0) {
            GetComponent<AudioSource>().clip = standard;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 1) {
            GetComponent<AudioSource>().clip = cursed;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 2) {
            GetComponent<AudioSource>().clip = pianoIntensifies;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 3) {
            GetComponent<AudioSource>().clip = cowbell;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 4) {
            GetComponent<AudioSource>().clip = bronto;
        }
        if(PlayerPrefs.GetInt("AudioSrc") == 5) {
            GetComponent<AudioSource>().clip = bongo;
        }
        GetComponent<AudioSource>().Play();

    }

    void Update() {
        if(!_bossMusic) {
        	if(PlayerPrefs.GetInt("AudioSrc") == 0) {
        		GetComponent<AudioSource>().clip = standard;
        	}
        	if(PlayerPrefs.GetInt("AudioSrc") == 1) {
        		GetComponent<AudioSource>().clip = cursed;
        	}
        	if(PlayerPrefs.GetInt("AudioSrc") == 2) {
        		GetComponent<AudioSource>().clip = pianoIntensifies;
        	}
            if(PlayerPrefs.GetInt("AudioSrc") == 3) {
                GetComponent<AudioSource>().clip = cowbell;
            }
            if(PlayerPrefs.GetInt("AudioSrc") == 4) {
                GetComponent<AudioSource>().clip = bronto;
            }
            if(PlayerPrefs.GetInt("AudioSrc") == 5) {
                GetComponent<AudioSource>().clip = bongo;
            }
        }



    }

    public void StartAudio() {
    	GetComponent<AudioSource>().Play();
    }
}
