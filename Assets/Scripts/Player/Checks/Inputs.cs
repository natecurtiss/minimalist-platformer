using UnityEngine;
using static UnityEngine.Input;

namespace Player
{
    class Inputs : MonoBehaviour
    {
        [SerializeField] float _jumpBuffer = 0.1f;
        float _jumpTimer;
        
        public float Horizontal { get; private set; }
        public bool Jump => _jumpTimer > 0;
        
        void Update()
        {
            Horizontal = GetAxisRaw("Horizontal");
            if (GetAxisRaw("Vertical") == 1)
                _jumpTimer = _jumpBuffer;
        }
    }
}