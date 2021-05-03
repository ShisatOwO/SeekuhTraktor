using UnityEngine;

namespace Gameplay
{
    public class PlayerController
    {
        private MonoBehaviour _parent;
        private Rigidbody2D _rigidbody2D;
        
        public PlayerController(MonoBehaviour parent)
        {
            _parent = parent;
        }

        public void Impulse(Vector2 vel)
        {
            Vector2 new_vel = vel; 
            _rigidbody2D = _parent.GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new_vel;
        }
    }
}