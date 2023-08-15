using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dialog;



public class LastLineBeforeFight : TextLine
{
    private bool _activateMark = false;
    private bool _setPosition = false;

    private Vector3 _store_start_position;
    private Rigidbody2D _rb;
    public GameObject Textbox;
    public GameObject MediaMark;
    private MarkController _markC;
    private bool _activateFight = false;
    // Start is called before the first frame update

    void Start()
    {
        _setPosition = false;
        _activateMark = false;   
        _activateFight = false;
        _markC = MediaMark.GetComponent<MarkController>();
        _rb = MediaMark.GetComponent<Rigidbody2D>();
    }


    public override void speak()
    {
      print("Hi");
        //_rb.velocity = new Vector2 (1,-100f);
        //Textbox = GameObject.Find("TextBox");
    }
}

