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
        //private GameObject _canvas;
        
        private float _maxSpeed;
        private float _acceleration;
        private float _deceleration;
        private float _jumpForce;
        private bool _inAir = true;
        private int _direction;

        public PlayerController(MonoBehaviour parent , float jumpForce, float maxSpeed, float acceleration, float deceleration)
        {
            _parent = parent;
            _rigidbody2D = _parent.GetComponent<Rigidbody2D>();
            _maxSpeed = maxSpeed;
            _jumpForce = jumpForce;
            _acceleration = acceleration;
            _deceleration = deceleration;
            //_canvas = GameObject.Find("Canvas");
            _vars = GameObject.Find("Main").GetComponent<Vars>();
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

            if (other.gameObject.CompareTag("BoundHor")) _inAir = false;

        }

        public void Move(int rl, bool jmp, bool crh)
        {
            Vector2 vel = _rigidbody2D.velocity;
            
            // Beschleunigung
            if (rl != 0)
            {
                float acl = _acceleration * Time.deltaTime * rl;
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
            
            _rigidbody2D.velocity = vel;
        }
    }
}