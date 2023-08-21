using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class NSkyController : MonoBehaviour
{
    public GameObject livehandler;
    public float maxSpeed_focus;
    public float maxSpeed_normal;
    private float maxSpeed;
    public float decc;
    private float acc;
    public float acc_focus;
    public float acc_normal;

    public AudioSource sfxHurt;

    private int _ud;
    private int _rl;
    private Rigidbody2D _rigid2D;
    private Vector2 _vel;
    private SpriteRenderer _spRender;

    public Vars _vars;

    // Start is called before the first frame update
    void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
        decc = decc / 100;
        acc = acc_normal / 100;
        _spRender = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("Enemy"))
            {
                sfxHurt.Play();
                livehandler.GetComponent<live_handler>().removeLive();
                //PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                //SceneManager.LoadScene("HighscoreAfterGame");
            }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate() {
        acc = Input.GetKey("space") ? acc_focus/100 : acc_normal/100;
        maxSpeed = Input.GetKey("space") ? maxSpeed_focus : maxSpeed_normal;
        Move(_rl, _ud);
    }

    void CheckInput() {

        _rl = 0;
        _ud = 0;

        //Desktop CTRL
        if (Input.GetButton("Right") || Input.GetAxisRaw("Horizontal") > 0) _rl = 1;
        else if (Input.GetButton("Left") ||  Input.GetAxisRaw("Horizontal") < 0) _rl = -1;
        if (Input.GetButton("Fire1") || Input.GetAxisRaw("Vertical") > 0) _ud = 1;
        else if (Input.GetButton("Crouch") ||  Input.GetAxisRaw("Vertical") < 0) _ud = -1;

        //if (Input.GetAxis("CrouchGamepad") > 0 || Input.GetButton("Crouch")) _crh = true;

        /*
        //mobile ctrl
        if (mobileSteerRight.pressed) _rl = 1;
        else if (mobileSteerLeft.pressed) _rl = -1;
        if (mobileSteerCrouch.pressed) _crh = true;
        else if (mobileSteerJump.pressed) _jmp = true;
        */

    }

    void Move(int rl, int ud) {

        _vel = _rigid2D.velocity;


        if(rl<0 && _vel.x > 0) {
            _vel = new Vector2 (0, _vel.y);
        }
        if(rl>0 && _vel.x < 0) {
            _vel = new Vector2 (0, _vel.y);
        }
        if(ud<0 && _vel.y > 0) {
            _vel = new Vector2 (_vel.x, 0);
        }
        if(ud>0 && _vel.y < 0) {
            _vel = new Vector2 (_vel.x, 0);
        }


        if(rl<0) {
            if(_vel.x - acc <= maxSpeed) {
                _vel = new Vector2 (-maxSpeed, _vel.y);
            } else {
                _vel = new Vector2 (_vel.x + (acc * Time.deltaTime), _vel.y);
            }
        }
        if(rl>0) {
            if(Mathf.Abs(_vel.x + acc) >= maxSpeed) {
                _vel = new Vector2 (maxSpeed, _vel.y);
            } else {
                _vel = new Vector2 (_vel.x + (-1 * acc * Time.deltaTime), _vel.y);
            }
        }
        if(rl == 0) {
            if(_vel.x > 0) {
                if(_vel.x - decc <= 0 ) {
                    _vel = new Vector2 (0f, _vel.y);
                } else {
                    _vel = new Vector2 (_vel.x - decc, _vel.y);
                }
            }
            if(_vel.x < 0) {
                if(_vel.x + decc >= 0 ) {
                    _vel = new Vector2 (0f, _vel.y);
                } else {
                    _vel = new Vector2 (_vel.x + decc, _vel.y);
                }
            }
        }

        if(ud<0) {
            if(Mathf.Abs(_vel.y + acc) >= maxSpeed) {
                _vel = new Vector2 (_vel.x, -maxSpeed);
            } else {
                _vel = new Vector2 (_vel.x, _vel.y - (acc * Time.deltaTime));
            }
        }
        if(ud>0) {
            if(Mathf.Abs(_vel.y + acc) >= maxSpeed) {
                _vel = new Vector2 (_vel.x, maxSpeed);
            } else {
                _vel = new Vector2 (_vel.x, _vel.y + acc * Time.deltaTime * -1);
            }
        }
        if(ud == 0) {
            if(_vel.y > 0) {
                if(_vel.y - decc <= 0 ) {
                    _vel = new Vector2 (_vel.x, 0f);
                } else {
                    _vel = new Vector2 (_vel.x, _vel.y  - decc);
                }
            }
            if(_vel.y < 0) {
                if(_vel.y + decc >= 0 ) {
                    _vel = new Vector2 (_vel.x, 0f);
                } else {
                    _vel = new Vector2 (_vel.x, _vel.y  + decc);
                }
            }
        }

        if(rl != 0) { _spRender.flipX = (rl < 0) ? true : false; }
        
        if(ud != 0) { _spRender.flipY = (ud < 0) ? true : false; }

        _rigid2D.velocity = _vel;

    }
}
