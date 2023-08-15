using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class RocketAnim : TextLine
{
    private bool _startAnim = false;
	public Transform trans;
    public Image Textbox;
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
        	trans.position += new Vector3(transform.position.x, 0.1f, transform.position.z);
        	if(trans.position.y >= 14) {
        		SceneManager.LoadScene("MediaMark"); 
        	}
        }
        
    }

    public override void speak()
    {
        //characterPortraitDisplay.sprite = characterPortrait;
        _startAnim = true;
        //Textbox = GameObject.Find("TextBox");
        Textbox.enabled = false;
    }
}
