using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class LineMoveMark : TextLine
{

    public TextLine nextLine2;
    public GameObject battleTheme;

    private bool _activateMark = false;
    private bool _setPosition = false;
    private bool _speak_stop = false;

    private Vector3 _store_start_position;
    private Rigidbody2D _rb;
    //public GameObject Textbox;
    public GameObject MediaMark;
    private MarkController _markC;
    private bool _activateFight = false;
    // Start is called before the first frame update

    void Start()
    {
        _speak_stop = false;
        _setPosition = false;
        _activateMark = false;   
        _activateFight = false;
        _markC = MediaMark.GetComponent<MarkController>();
        _rb = MediaMark.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(_activateMark && !_activateFight && !_setPosition) {
            if(MediaMark.transform.position.y > 2) {
                MediaMark.transform.position += new Vector3 (0f, -1f, 0f);
            } else {
                _setPosition = true;
                _store_start_position = MediaMark.transform.position;

            }
        }
        if (_activateMark && _setPosition && !_speak_stop)
        {
            nextLine2.speak();
            _speak_stop = true;

        }
        
        if(_activateMark && _setPosition && !_activateFight) {
            MediaMark.transform.position = _store_start_position;
        }
    }

    public override void speak()
    {
        battleTheme.GetComponent<AudioSource>().Play();
        _activateMark = true;
        //_rb.velocity = new Vector2 (1,-100f);
        //Textbox = GameObject.Find("TextBox");
    }

    public void deactivateMark() {
        _activateMark = false;
    }
}
