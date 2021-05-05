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
        private GameObject _canvas;
        
        private float _maxSpeed;
        private float _acceleration;
        private float _deceleration;
        private float _jumpForce;
        private bool _inAir;

        public PlayerController(MonoBehaviour parent , float jumpForce, float maxSpeed, float acceleration, float deceleration)
        {
            _parent = parent;
            _rigidbody2D = _parent.GetComponent<Rigidbody2D>();
            _maxSpeed = maxSpeed;
            _jumpForce = jumpForce;
            _acceleration = acceleration;
            _deceleration = deceleration;
            _canvas = GameObject.Find("Canvas");
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

        public void Move(float rl, bool jmp, bool crh)
        {
            _rigidbody2D.velocity += new Vector2(_acceleration*rl*Time.deltaTime, 0);

            if (Math.Abs(_rigidbody2D.velocity.x) > Math.Abs(_maxSpeed * rl))
                _rigidbody2D.velocity = new Vector2(_maxSpeed * rl, _rigidbody2D.velocity.y);

            if (rl != 0) return;

            float force = _deceleration * (int) (-_rigidbody2D.velocity.x / _rigidbody2D.velocity.x);
            if (Math.Abs(_rigidbody2D.velocity.x) - Math.Abs(force) < 0)
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            else
                _rigidbody2D.velocity =
                    new Vector2(_rigidbody2D.velocity.x + force * Time.deltaTime, _rigidbody2D.velocity.y);
        }
    }
}