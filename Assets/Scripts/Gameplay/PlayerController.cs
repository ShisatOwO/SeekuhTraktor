using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour 
    {
        private MonoBehaviour _parent;
        private Rigidbody2D _rigidbody2D;
        private float _maxSpeed;
        private float _acceleration;
        
        private float _jumpForce;
        private float _rl;
        private bool _jmp;
        private bool _crh;
        
        
        public PlayerController(MonoBehaviour parent , float jumpForce, float maxSpeed, float acceleration)
        {
            _parent = parent;
            _rigidbody2D = _parent.GetComponent<Rigidbody2D>();
            _maxSpeed = maxSpeed;
            _jumpForce = jumpForce;
            _acceleration = acceleration;
        }
        
        public void PlayerCollision(Collision2D other)
        {
            if (other.gameObject.CompareTag("BoundVert")) 
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

        public void ReceiveInput(float rl, bool jmp, bool crh)
        {
            _rl = rl;
            _jmp = jmp;
            _crh = crh;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x + _acceleration * _rl * Time.deltaTime, _rigidbody2D.velocity.y);
            
            if (Math.Abs(_rigidbody2D.velocity.x) > Math.Abs(_maxSpeed * _rl))
                _rigidbody2D.velocity = new Vector2(_maxSpeed * _rl, _rigidbody2D.velocity.y);
            
            if (Math.Abs(_rigidbody2D.velocity.x) > 0 && _rl == 0)
            {
                float force = _acceleration * Time.deltaTime;
                if (Math.Abs(_rigidbody2D.velocity.x) < force) force = 0;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x - force , _rigidbody2D.velocity.y);
                
            }
        }
    }
}