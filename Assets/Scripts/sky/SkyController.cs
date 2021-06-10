using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


public class SkyController : MonoBehaviour
{

    private MonoBehaviour _parent;
    private Rigidbody2D _rigidbody2D;
    private Vars _vars;

    public float _maxSpeed;
    public float _acceleration;
    public float _deceleration;
    public float downSpeed;
    public float _jumpForce;
    public float _jumpHeight;
    private bool _inAir = true;
    private bool _atJumpPeak;
    public float _airMobility;
    public float fallschirmDivideSpeed;
    private bool _crouched;
    public Sprite _crouch;
    public Sprite _normal;
    private SpriteRenderer _fallschirmObjectRenderer;
    private Transform _fallschirmTransform;
    public GameObject _fallschirmObject;

    public Button mobileBtnL;
    public Button mobileBtnR;
    public Button mobileBtnU;
    public Button mobileBtnD;


    private BtnClicker mobileSteerLeft;
    private BtnClicker mobileSteerRight;
    private BtnClicker mobileSteerJump;
    private BtnClicker mobileSteerCrouch;


    private Transform _collNorm;
    private Transform _collCrh;


    private SpriteRenderer _spRender;

    public Vector2 vel;

    private int _rl;
    private int _ud;
    private bool _isMoving;
    private bool _jmp;
    private bool _crh;
    private int _cf = 10;

    private float _countJumpSec = 0f;
    private float _colorChangeSpeed = 1f;
    private bool rainbowActive = false;
    private float _countRainbowSec = 0f;
    private BoxCollider2D collide2D;
    private int countJFrames;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spRender= GetComponent<SpriteRenderer>();
        //_fallschirmObjectRenderer = _fallschirmObject.GetComponent<SpriteRenderer>();
        //_fallschirmTransform = _fallschirmObject.GetComponent<Transform>();
        _vars = GameObject.Find("Main").GetComponent<Vars>();
        _collNorm = gameObject.transform.Find("CollisionNormal");
        //_collCrh = gameObject.transform.Find("CollisionCrouch");


        mobileSteerLeft = mobileBtnL.GetComponent<Button>().GetComponent<BtnClicker>();
        mobileSteerRight = mobileBtnR.GetComponent<Button>().GetComponent<BtnClicker>();
        mobileSteerJump = mobileBtnU.GetComponent<Button>().GetComponent<BtnClicker>();
        mobileSteerCrouch = mobileBtnD.GetComponent<Button>().GetComponent<BtnClicker>();
        //_parent = gameObject.MonoBehaviour;
        
    }

    // Update is called once per frame
    void Update()
    {
       CheckInput();
    }

    void FixedUpdate()
    {
        Move(_rl,_ud,_jmp,_crh);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoundVert")) 
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

            if (other.gameObject.CompareTag("Enemy") && !rainbowActive)
            {
                PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                SceneManager.LoadScene("HighscoreAfterGame");
            } else if(other.gameObject.CompareTag("Enemy") && rainbowActive) {
                try {
                    other.gameObject.SendMessage("MushDelete", other.gameObject);
                    other.gameObject.transform.parent.gameObject.gameObject.SendMessage("MushDelete", other.gameObject.transform.parent.gameObject);
                }
                catch (System.Exception e) {
                    Debug.Log("SomeError");
                }

            }

            if (other.gameObject.CompareTag("BoundHor"))
            {
                _rigidbody2D.velocity = new Vector2 (_rigidbody2D.velocity.x, 0f);
                _atJumpPeak = false;
                _fallschirmObjectRenderer.enabled = false;
                _inAir = false;
            }
            if (other.gameObject.CompareTag("Upgrade"))
            {
                Physics2D.IgnoreCollision(_collNorm.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(_collCrh.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
                rainbowActive = true;
                try {
                    other.gameObject.SendMessage("MushDelete", other.gameObject);
                }
                catch (System.Exception e) {
                    Debug.Log("Erroorr");
                }
            }
    }

    void CheckInput()
    {
        _rl = 0;
        _ud = 0;

        _jmp = Input.GetButton("Jump");
        _crh = false;


        //Desktop CTRL
        if (Input.GetButton("Right") || Input.GetAxisRaw("Horizontal") > 0) _rl = 1;
        else if (Input.GetButton("Left") ||  Input.GetAxisRaw("Horizontal") < 0) _rl = -1;
        if (Input.GetButton("Fire1") || Input.GetAxisRaw("Vertical") > 0) _ud = 1;
        else if (Input.GetButton("Crouch") ||  Input.GetAxisRaw("Vertical") < 0) _ud = -1;
        if (Input.GetAxis("CrouchGamepad") > 0 || Input.GetButton("Crouch")) _crh = true;

        /*
        //mobile ctrl
        if (mobileSteerRight.pressed) _rl = 1;
        else if (mobileSteerLeft.pressed) _rl = -1;
        if (mobileSteerCrouch.pressed) _crh = true;
        else if (mobileSteerJump.pressed) _jmp = true;
        */
    }

    void Move(int rl, int ud, bool jmp, bool crh) {

            vel = _rigidbody2D.velocity ;
        

            /*
            // Beschleunigung
            if (rl != 0)
            {
                float acl = _acceleration * Time.deltaTime * rl;
                if (Mathf.Abs(vel.x + acl) > Mathf.Abs(_maxSpeed)) vel.x = _maxSpeed * rl;
                else vel.x += acl;
                _spRender.flipX = (rl < 0) ? true : false;
            }*/


            if (ud != 0)
            {
                float aclu = _acceleration * Time.deltaTime * rl;
                if (Mathf.Abs(vel.y + aclu) > Mathf.Abs(_maxSpeed)) vel.y = _maxSpeed * rl;
                else vel.y += aclu;
                _spRender.flipX = (rl < 0) ? true : false;
            }

            // Ausbremsung
            /*
            if (rl == 0)
            {
                int dir = 0;
                if (vel.x != 0) dir = (int)(-vel.x / Mathf.Abs(vel.x));
                if (Mathf.Abs(vel.x) - _deceleration * Time.deltaTime < 0) vel.x = 0;
                else vel.x += _deceleration * dir * Time.deltaTime;
            }

            if (ud == 0)
            {
                int diru = 0;
                if (vel.y != 0) diru = (int)(-vel.y / Mathf.Abs(vel.y));
                if (Mathf.Abs(vel.y) - _deceleration * Time.deltaTime < 0) vel.y = 0;
                else vel.y += _deceleration * diru * Time.deltaTime;
            }
            */

            /*
            else if (_inAir)
            {
                int dir = 0;
                if (vel.x != 0) dir = (int)(-vel.x / Mathf.Abs(vel.x));
                if (Mathf.Abs(vel.x) - _deceleration * Time.deltaTime < 0) vel.x = 0;
                else vel.x += _deceleration / 8 * dir * Time.deltaTime;
            }*/

            
            // Kein springen Mehr wenn man in der Luft Springen los lässt
            //if (!jmp && _inAir) _atJumpPeak = true;
            
            //Mehr velocity rl in air
            //else if (jmp && !_inAir && !_crouched) vel.x *= 0.3f;
            
            //Test if vel < 0 for debug
            /*if(jmp && vel.y <= 0f && !_inAir) {
                vel.y = 0f;
            }*/
            
            

            // Springen
            /*
            if (jmp && !_inAir)
            {

                //Frowins Jump-Funktion
                vel = Vector2.up * _jumpForce;
                //Debug.Log("Jump");
                _inAir = true;

                //Sound Bool = true
                _vars.justJumped = true;
            }

            // Höher Springen wenn mans gedrückt hält
            if (jmp && _inAir && !_atJumpPeak)
            {
                
                if(_countJumpSec < _jumpHeight && !_atJumpPeak) {
                    vel = vel + new Vector2(0f, 0.5f);
                    //Debug.Log("executed");
                    countJFrames++;

                    _countJumpSec = _countJumpSec + Time.deltaTime;
                }
                if(countJFrames >= _jumpHeight)
                {
                    //Debug.Log("else");
                    _atJumpPeak = true;
                    _countJumpSec = 0f;
                    countJFrames = 0;
                }
            }

            //falschirm
            if (jmp && _inAir && _atJumpPeak && vel.y < -1 && !_crouched)
            {
                //Debug.Log("fallschirm");
                _fallschirmObjectRenderer.enabled = true;
                vel.y /= fallschirmDivideSpeed;
            }

            if (crh && !_crouched)
            //if (1 == 1)
            {
                

                if (_inAir) {
                        vel = vel - new Vector2(0f, downSpeed);
                        //_parent.transform.position -= new Vector3 (0f, 0.05f, 0f);
                    } else {
                    _fallschirmObjectRenderer.enabled = false;

                    //collide2D = _parent.gameObject.transform.Find("CollisionNormal");
                    //collide2D.size = new Vector2(collide2D.size.x, 5.874467f);

                    _collNorm.gameObject.SetActive(false);
                    _collCrh.gameObject.SetActive(true);
                    _spRender.sprite = _crouch;
                    //_parent.transform.position -= new Vector3 (0f, 0.6f, 0f);
                    
                    //_deceleration /= 8;
                    _acceleration /= 8;
                    _maxSpeed /= 1.75f;
                    _crouched = true;
                }
            }

            else if (!crh && _crouched)
            {

                _collNorm.gameObject.SetActive(true);
                _collCrh.gameObject.SetActive(false);

                
                //collide2D.size = new Vector2(collide2D.size.x, 5.874467f);


               _spRender.sprite = _normal;
                //_parent.transform.position += new Vector3 (0f, 0.6f, 0f);
                _rigidbody2D.gravityScale = 5f;
                //_deceleration *= 8;
                _acceleration *= 8;
                _maxSpeed *= 1.75f;
                _crouched = false;
            }*/

            //faster left and right turns
            /*
            if(vel.x > 0 && rl < 0) {
                vel = new Vector2(0f, vel.y);
            }
            else if(vel.x < 0 && rl > 0) {
                vel = new Vector2(0f, vel.y);
            }
            */

            /*
            //turn fallschirm
            if(_spRender.flipX == true) {
                _fallschirmObjectRenderer.flipX = true;
                _fallschirmTransform.position = transform.position + new Vector3(1.05f,1.35f,0f);
            } else {
                _fallschirmObjectRenderer.flipX = false;
                _fallschirmTransform.position = transform.position + new Vector3(-1.05f,1.35f,0f); 
            }
            //remove slower fallschirm falling
            if(!jmp && _fallschirmObjectRenderer.enabled) {
                _fallschirmObjectRenderer.enabled = false;
                vel.y *= fallschirmDivideSpeed;   
            }
            if(rainbowActive) {
                
                float lerp = Mathf.PingPong(Time.time, 1f) / 1f;
                _spRender.material.color = Color.Lerp(Color.red, Color.green, lerp);
                  
                _countRainbowSec = _countRainbowSec + Time.deltaTime;
                if(_countRainbowSec >= 5) {
                    _countRainbowSec = 0;
                    rainbowActive = false;
                    //_cf = 10;
                    _spRender.material.SetColor("_Color", Color.white);
                }
            }*/

            

            _rigidbody2D.velocity = vel;
    }



}
