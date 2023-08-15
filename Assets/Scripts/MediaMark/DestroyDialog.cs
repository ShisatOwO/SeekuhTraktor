using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class DestroyDialog : TextLine
{
    //private bool _activateMark = false;
    //private bool _setPosition = false;

    //private Vector3 _store_start_position;
    //private Rigidbody2D _rb;
    public GameObject Textbox;
    public GameObject MoveMarkLine;
    public GameObject MediaMark;
    private MarkController _markC;
    private LineMoveMark _moveMarkSkript;
    private bool _activateFight = false;

    // Start is called before the first frame update
    void Start()
    {
        //_setPosition = false;
        //_activateMark = false;   
        //_activateFight = false;
        _markC = MediaMark.GetComponent<MarkController>();
        _moveMarkSkript = MoveMarkLine.GetComponent<LineMoveMark>();
        //_rb = MediaMark.GetComponent<Rigidbody2D>();
    }

/*    public override void Update() 
    {
        if (Input.GetKeyDown("space"))
        {
          if (finished && !answered && last_line != null)
          {
            text.text = "";
            last_line.speak();
            this.enabled = false;
          }
          
          else if (finished)
          {
            answered = true;
          }
        }
      }*/

    // Update is called once per frame
/*    void FixedUpdate()
    {
        if(_activateMark && !_activateFight && !_setPosition) {
            if(MediaMark.transform.position.y > 2) {
                MediaMark.transform.position += new Vector3 (0f, -1f, 0f);
            } else {
                _setPosition = true;
                _store_start_position = MediaMark.transform.position;
            }
        }
        if(_setPosition && !_activateFight) {
            MediaMark.transform.position = _store_start_position;
        }
    }*/

    public override void speak()
    {
        activateFight();
        //_rb.velocity = new Vector2 (1,-100f);
        //Textbox = GameObject.Find("TextBox");
    }

    public void activateFight() {
        _moveMarkSkript.deactivateMark();
        print("Fight activated");
        //_activateFight = true;
        _markC.startFight = true;
        Textbox.SetActive(false);

    }
}
