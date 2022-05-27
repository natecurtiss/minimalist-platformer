using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Physics2D;

namespace Player
{
    class GroundCheck : MonoBehaviour
    {
        [SerializeField] LayerMask _layer;
        [SerializeField] float _distance = 1.66f;
        [SerializeField] float _coyoteTime = 0.2f;

        float _groundTimer;
        
        public bool IsGrounded => _groundTimer > 0;

        void Update()
        {
            var hit = Raycast(transform.position, Vector2.down, _distance, _layer);
            if (hit.collider is not null) 
                _groundTimer = _coyoteTime;
        }
    }
}