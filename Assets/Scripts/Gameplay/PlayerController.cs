using UnityEngine;

namespace Gameplay
{
    public class PlayerController
    {
        private MonoBehaviour _parent;
        
        public PlayerController(MonoBehaviour parent)
        {
            _parent = parent;
        }
    }
}