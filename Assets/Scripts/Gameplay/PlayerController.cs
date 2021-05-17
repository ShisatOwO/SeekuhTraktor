using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class PlayerController
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
        private SpriteRenderer _fallschirmObject;


        private float _countJumpSec = 0f;

        public PlayerController(MonoBehaviour parent, 
                                float jumpForce, 
                                float jumpHeight, 
                                float airMobility, 
                                float maxSpeed, 
                                float acceleration, 
                                float deceleration,
                                Sprite normal,
                                Sprite crouch,
                                SpriteRenderer fallschirmObject)
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
        }
        
        public void PlayerCollision(Collision2D other)
        {
            if (other.gameObject.CompareTag("BoundVert")) 
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

            if (other.gameObject.CompareTag("Enemy"))
            {
                PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                //SceneManager.LoadScene("HighscoreAfterGame");
            }

            if (other.gameObject.CompareTag("BoundHor"))
            {
                _inAir = false;
                _atJumpPeak = false;
                _fallschirmObject.enabled = false;
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

            // Kein springen Mehr wenn man in der Luft Springen los lässt
            if (!jmp && _inAir) _atJumpPeak = true;
            else if (jmp && !_inAir && !_crouched) vel.x *= 0.3f;
            
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
                Debug.Log("Jump");
                _inAir = true;
            }

            // Höher Springen wenn mans gedrückt hält
            if (jmp && _inAir && !_atJumpPeak)
            {
            	if(_countJumpSec < _jumpHeight) {
	            	vel = vel + new Vector2(0f, 0.5f);
	            	//Debug.Log(_countJumpSec);
	            	_countJumpSec = _countJumpSec + Time.deltaTime;
	            } else {
	            	_atJumpPeak = true;
	            	_countJumpSec = 0f;
	            }
            }
            if (_inAir && _atJumpPeak)
            {
                Debug.Log("fallschirm");
                _fallschirmObject.enabled = true;
            }

            if (crh && !_crouched)
            {
                _fallschirmObject.enabled = false;

            	if (_inAir) {
                		vel = vel - new Vector2(0f, 1f);
                		//vel.x = 0;
                	} else {
	                _parent.gameObject.transform.Find("CollisionNormal").gameObject.SetActive(false);
	                _parent.gameObject.transform.Find("CollisionCrouch").gameObject.SetActive(true);
	                _parent.GetComponent<SpriteRenderer>().sprite = _crouch;
	                
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
                _parent.GetComponent<SpriteRenderer>().sprite = _normal;
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
            _rigidbody2D.velocity = vel;
        }
    }
}