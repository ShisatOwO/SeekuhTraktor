﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        private MonoBehaviour _parent;
        private Rigidbody2D _rigidbody2D;
        private Vars _vars;

        private float _maxSpeed;
        private float _acceleration;
        private float _deceleration;
        private float _jumpForce;
        private float _jumpHeight;
        private bool _inAir = true;
        private bool _atJumpPeak;
        private float _airMobility;
        private bool _crouched;
        private Sprite _crouch;
        private Sprite _normal;
        private SpriteRenderer _fallschirmObjectRenderer;
        private GameObject _fallschirmObject;


        private float _countJumpSec = 0f;
        private float _colorChangeSpeed = 1f;
        private bool rainbowActive = false;
        private float _countRainbowSec = 0f;
        private BoxCollider2D collide2D;

        public PlayerController(MonoBehaviour parent, 
                                float jumpForce, 
                                float jumpHeight, 
                                float airMobility, 
                                float maxSpeed, 
                                float acceleration, 
                                float deceleration,
                                Sprite normal,
                                Sprite crouch,
                                GameObject fallschirmObject)
        {
            _parent = parent;
            _rigidbody2D = _parent.GetComponent<Rigidbody2D>();
            _vars = GameObject.Find("Main").GetComponent<Vars>();
            _maxSpeed = maxSpeed;
            _jumpForce = jumpForce;
            _jumpHeight = jumpHeight;
            _acceleration = acceleration;
            _deceleration = deceleration;
            _airMobility = airMobility;
            _crouched = false;
            _normal = normal;
            _crouch = crouch;
            _fallschirmObject = fallschirmObject;
            _fallschirmObjectRenderer = fallschirmObject.GetComponent<SpriteRenderer>();
        }
        
        public void PlayerCollision(Collision2D other)
        {
            if (other.gameObject.CompareTag("BoundVert")) 
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

            if (other.gameObject.CompareTag("Enemy") && !rainbowActive)
            {
                PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                //SceneManager.LoadScene("HighscoreAfterGame");
            } else if(other.gameObject.CompareTag("Enemy") && rainbowActive) {
                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("BoundHor"))
            {
                _inAir = false;
                _atJumpPeak = false;
                _fallschirmObjectRenderer.enabled = false;
            }
            if (other.gameObject.CompareTag("Upgrade"))
            {
                Physics2D.IgnoreCollision(_parent.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
                rainbowActive = true;
                Destroy(other.gameObject);
            }

        }

        public void Move(int rl, bool jmp, bool crh)
        {
            Vector2 vel = _rigidbody2D.velocity;

            // Beschleunigung
            if (rl != 0)
            {
                float acl = _acceleration * Time.deltaTime * rl;
                if (_inAir) acl = _acceleration * Time.deltaTime * rl * _airMobility;
                if (Math.Abs(vel.x + acl) > Math.Abs(_maxSpeed)) vel.x = _maxSpeed * rl;
                else vel.x += acl;
                _parent.GetComponent<SpriteRenderer>().flipX = (rl < 0) ? true : false;
            }

            // Ausbremsung
            else if (!_inAir)
            {
                int dir = 0;
                if (vel.x != 0) dir = (int)(-vel.x / Math.Abs(vel.x));
                if (Math.Abs(vel.x) - _deceleration * Time.deltaTime < 0) vel.x = 0;
                else vel.x += _deceleration * dir * Time.deltaTime;
            }

            else if (_inAir)
            {
                int dir = 0;
                if (vel.x != 0) dir = (int)(-vel.x / Math.Abs(vel.x));
                if (Math.Abs(vel.x) - _deceleration * Time.deltaTime < 0) vel.x = 0;
                else vel.x += _deceleration / 8 * dir * Time.deltaTime;
            }

            
            // Kein springen Mehr wenn man in der Luft Springen los lässt
            if (!jmp && _inAir) _atJumpPeak = true;
            
            //Mehr velocity rl in air
            //else if (jmp && !_inAir && !_crouched) vel.x *= 0.3f;
            
            
            // Springen
            if (jmp && !_inAir)
            {
                

               /* Raihgks Jump-Funktion

                float aclY = _jumpHeight*0.1f +  _jumpForce * Time.deltaTime;
                if (vel.y + aclY > _jumpHeight)
                {
                    vel.y += vel.y + aclY - _jumpHeight;
                    _atJumpPeak = true;
                }
                vel.y += aclY;
                */

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
	            	_countJumpSec = _countJumpSec + Time.deltaTime;
	            }
                if(_countJumpSec >= _jumpHeight)
                {
                    //Debug.Log("else");
	            	_atJumpPeak = true;
	            	_countJumpSec = 0f;
	            }


            //falschirm
            }
            if (jmp && _inAir && _atJumpPeak && vel.y < -0.5 && !_crouched)
            {
                //Debug.Log("fallschirm");
                _fallschirmObjectRenderer.enabled = true;
                vel.y /= 1.25f;
            }

            if (crh && !_crouched)
            //if (1 == 1)
            {
                

            	if (_inAir) {
                		vel = vel - new Vector2(0f, 1f);
                		//vel.x = 0;
                	} else {
                    _fallschirmObjectRenderer.enabled = false;

                    //collide2D = _parent.gameObject.transform.Find("CollisionNormal");
	                //collide2D.size = new Vector2(collide2D.size.x, 5.874467f);

                    _parent.gameObject.transform.Find("CollisionNormal").gameObject.SetActive(false);
	                _parent.gameObject.transform.Find("CollisionCrouch").gameObject.SetActive(true);
	                _parent.GetComponent<SpriteRenderer>().sprite = _crouch;
                    //_parent.transform.position -= new Vector3 (0f, 0.6f, 0f);
	                
	                //_deceleration /= 8;
	                _acceleration /= 8;
                    _maxSpeed /= 1.75f;
	                _crouched = true;
	            }
            }

            else if (!crh && _crouched)
            {

                _parent.gameObject.transform.Find("CollisionNormal").gameObject.SetActive(true);
                _parent.gameObject.transform.Find("CollisionCrouch").gameObject.SetActive(false);

                
                //collide2D.size = new Vector2(collide2D.size.x, 5.874467f);


                _parent.GetComponent<SpriteRenderer>().sprite = _normal;
                //_parent.transform.position += new Vector3 (0f, 0.6f, 0f);
                _rigidbody2D.gravityScale = 5f;
                //_deceleration *= 8;
                _acceleration *= 8;
                _maxSpeed *= 1.75f;
                _crouched = false;
            }

            //faster left and right turns

            if(vel.x > 0 && rl < 0) {
                vel = new Vector2(0f, vel.y);
            }
            else if(vel.x < 0 && rl > 0) {
                vel = new Vector2(0f, vel.y);
            }

            //turn fallschirm
            if(_parent.GetComponent<SpriteRenderer>().flipX == true) {
                _fallschirmObjectRenderer.flipX = true;
                _fallschirmObject.transform.position = _parent.transform.position + new Vector3(1.05f,1.35f,0f);
            } else {
                _fallschirmObjectRenderer.flipX = false;
                _fallschirmObject.transform.position = _parent.transform.position + new Vector3(-1.05f,1.35f,0f); 
            }
            //remove slower fallschirm falling
            if(!jmp && _fallschirmObjectRenderer.enabled) {
                _fallschirmObjectRenderer.enabled = false;
                vel.y *= 1.25f;   
            }
            if(rainbowActive) {
                _parent.GetComponent<SpriteRenderer>().color = RainbowColors(_parent.GetComponent<SpriteRenderer>().color);
                _countRainbowSec = _countRainbowSec + Time.deltaTime;
                if(_countRainbowSec >= 5) {
                    _countRainbowSec = 0;
                    rainbowActive = false;
                    _parent.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }
            }
            _rigidbody2D.velocity = vel;
        }

        public Color RainbowColors(Color color) 
        {
                // convert from RGB to HSV
            Color.RGBToHSV(color, out float hue, out float sat, out float val);
     
            // shift hue by amount
            hue += 0.01f;
            sat = 1f;
            val = 1f;

            //Debug.Log(Color.HSVToRGB(hue, sat, val));
            // convert back to RGB and return the color
            return Color.HSVToRGB(hue, sat, val);
        /*
            if(rainbowActive) {
                _parent.GetComponent<SpriteRenderer>().material.SetColor("_Color", HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * _colorChangeSpeed, 1), 1, 1)));
                _countRainbowSec = _countRainbowSec + Time.deltaTime;
                if(_countRainbowSec >= 5) {
                    _countRainbowSec = 0;
                    rainbowActive = false;
                }
            }*/
        }
    }
}