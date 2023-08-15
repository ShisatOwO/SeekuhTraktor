using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class DestroyDialog : TextLine
{
    private bool _activateMark = false;
    private Rigidbody2D _rb;
    public GameObject Textbox;
    public GameObject MediaMark;
    private MarkController _markC;
    private bool _activateFight = false;
    // Start is called before the first frame update
    void Start()
    {
        _activateMark = false;   
        _activateFight = false;
        _markC = MediaMark.GetComponent<MarkController>();
        _rb = MediaMark.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_activateMark && !_activateFight) {
            if(MediaMark.transform.position.y > 2) {
                MediaMark.transform.position += new Vector3 (0f, -1f, 0f);
            } else {
                Textbox.SetActive(false);
                _activateFight = true;
                _markC.startFight = true;
            }
        }
    }

    public override void speak()
    {
        _activateMark = true;
        //_rb.velocity = new Vector2 (1,-100f);
        //Textbox = GameObject.Find("TextBox");
    }
}
