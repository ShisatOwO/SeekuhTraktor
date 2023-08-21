using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class RocketAnim : TextLine
{
    public float posX;
    private bool _startAnim = false;
	public Transform trans;
    public GameObject Textbox;
    // Start is called before the first frame update
    void Start()
    {
        _startAnim = false;
    	trans = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_startAnim == true) {
        	trans.position += new Vector3(posX, 0.1f, 0);
        	if(trans.position.y >= 14) {
        		SceneManager.LoadScene("MediaMark"); 
        	}
        }
        
    }

    public override void speak()
    {
        Textbox.SetActive(false);
        //characterPortraitDisplay.sprite = characterPortrait;
        _startAnim = true;
        //Textbox = GameObject.Find("TextBox");
    }
}
