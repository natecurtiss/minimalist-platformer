using UnityEngine;
using UnityEngine.Events;
using Utils;
using static Utils.Direction;
using static UnityEngine.Physics2D;

namespace Player
{
    class WallCheck : MonoBehaviour
    {
        [SerializeField] LayerMask _layer;
        [SerializeField] float _distance = 1.5f;

        public bool IsOnWall { get; private set; }
        public Direction WallSide { get; private set; } = None;
        
        void Update()
        {
            var left = Raycast(transform.position, Vector2.left, _distance, _layer);
            var right = Raycast(transform.position, Vector2.right, _distance, _layer);
            if (left.collider is not null)
            {
                IsOnWall = true;
                WallSide = Left;
            }
            else if (right.collider is not null)
            {
                IsOnWall = true;
                WallSide = Right;
            }
            else
            {
                IsOnWall = false;
                WallSide = None;
            }
        }
    }
}