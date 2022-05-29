using UnityEngine;
using static UnityEngine.Input;
using static UnityEngine.Time;

namespace MP.Player.Checks
{
    class Inputs : MonoBehaviour
    {
        [SerializeField] float _jumpBuffer = 0.1f;
        float _jumpTimer;
        
        public float Horizontal { get; private set; }
        public bool Jump => _jumpTimer > 0;
        
        void Update()
        {
            TickTimers();
            GetInput();
        }

        void TickTimers() => _jumpTimer -= deltaTime;

        void GetInput()
        {
            Horizontal = GetAxisRaw("Horizontal");
            if (GetAxisRaw("Vertical") == 1)
                _jumpTimer = _jumpBuffer;
        }

        public void ResetJump() => _jumpTimer = 0f;
    }
}