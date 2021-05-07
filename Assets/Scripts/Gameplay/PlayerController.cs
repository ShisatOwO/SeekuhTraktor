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

        public PlayerController(MonoBehaviour parent, 
                                float jumpForce, 
                                float jumpHeight, 
                                float airMobility, 
                                float maxSpeed, 
                                float acceleration, 
                                float deceleration,
                                Sprite normal,
                                Sprite crouch)
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
        }
        
        public void PlayerCollision(Collision2D other)
        {
            if (other.gameObject.CompareTag("BoundVert")) 
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

            if (other.gameObject.CompareTag("Enemy"))
            {
                PlayerPrefs.SetInt("ScoreSceneOverdub", _vars.scoreInt);
                SceneManager.LoadScene("HighscoreAfterGame");
            }

            if (other.gameObject.CompareTag("BoundHor"))
            {
                _inAir = false;
                _atJumpPeak = false;
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
            else if (jmp && !_inAir) vel.x *= 0.3f;
            
            // Springen
            if (jmp && !_atJumpPeak)
            {
                _inAir = true;
                float aclY = _jumpHeight*0.1f +  _jumpForce * Time.deltaTime;
                if (vel.y + aclY > _jumpHeight)
                {
                    vel.y += vel.y + aclY - _jumpHeight;
                    _atJumpPeak = true;
                }
                vel.y += aclY;
            }

            if (crh && !_crouched)
            {
                _parent.gameObject.transform.Find("CollisionNormal").gameObject.SetActive(false);
                _parent.gameObject.transform.Find("CollisionCrouch").gameObject.SetActive(true);
                _parent.GetComponent<SpriteRenderer>().sprite = _crouch;
                _rigidbody2D.gravityScale *= 4;
                vel.x = 0;
                _crouched = true;
            }
            else if (!crh && _crouched)
            {
                _parent.gameObject.transform.Find("CollisionNormal").gameObject.SetActive(true);
                _parent.gameObject.transform.Find("CollisionCrouch").gameObject.SetActive(false);
                _parent.GetComponent<SpriteRenderer>().sprite = _normal;
                _rigidbody2D.gravityScale /= 4;
                _crouched = false;
            }
            
            _rigidbody2D.velocity = vel;
        }
    }
}