using UnityEngine;
using static UnityEngine.Color;
using static UnityEngine.Gizmos;
using static UnityEngine.Physics2D;
using static UnityEngine.Time;

namespace MP.Player.Checks
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
            _groundTimer -= deltaTime;
            var hit = Raycast(transform.position, Vector2.down, _distance, _layer);
            if (hit.collider is not null) 
                _groundTimer = _coyoteTime;
        }

        void OnDrawGizmos()
        {
            color = magenta;
            DrawRay(transform.position, Vector3.down * _distance);
        }

        public void Reset() => _groundTimer = 0f;
    }
}