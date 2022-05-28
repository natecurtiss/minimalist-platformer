using System;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Mathf;

namespace Player
{ 
    [Serializable]
    abstract class Move : State
    {
        [SerializeField] UnityEvent _onStartMoving;
        [SerializeField] UnityEvent _onStopMoving;
        [SerializeField] UnityEvent<int> _onChangeDirection;
        
        [field: SerializeField]
        protected float Speed { get; private set; } = 20f;

        [field: SerializeField]
        protected float Acceleration { get; private set; } = 0.4f;

        [field: SerializeField]
        protected float Deceleration { get; private set; } = 0.2f;
        
        protected PlayerController Player { get; private set; }

        bool _canMove;
        bool _isMoving;

        public override void Init(PlayerController player) => Player = player;

        public override void Enter() { }

        public override void FixedUpdate()
        {
            if (_canMove)
            {
                if (Player.Inputs.Horizontal != 0 && !_isMoving)
                {
                    _isMoving = true;
                    _onStartMoving.Invoke();
                }
                else if (Player.Inputs.Horizontal == 0 && _isMoving)
                {
                    _isMoving = false;
                    _onStopMoving.Invoke();
                }
                var target = Speed * Player.Inputs.Horizontal;
                var t = target == 0 ? Deceleration : Acceleration;
                var lerp = Lerp(Player.Rigidbody.velocity.x, target, t);
                Player.Rigidbody.velocity = new(lerp, Player.Rigidbody.velocity.y);
                if (_isMoving)
                    _onChangeDirection.Invoke((int) Player.Inputs.Horizontal);
            }
        }

        public override void Exit()
        {
            _canMove = true;
            if (_isMoving)
            {
                _isMoving = false;
                _onStopMoving.Invoke();
            }
        }

        protected void ResumeMovement() => _canMove = true;

        protected void PauseMovement() => _canMove = false;
    }
}