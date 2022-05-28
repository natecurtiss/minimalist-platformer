using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using static Player.StateID;
using static UnityEngine.Time;

namespace Player
{
    [Serializable]
    class Airborne : Move
    {
        [SerializeField] Vector2 _wallJumpBounce = Vector2.one * 20;
        [SerializeField] float _wallJumpFreeze = 1f;
        [SerializeField, Space] UnityEvent _onLand;
        [SerializeField, Space] UnityEvent _onWallJump;
        
        readonly Timer _wallJumpTimer = new();

        public override void Enter()
        {
            base.Enter();
            _wallJumpTimer.OnFinished += Start;
        }

        public override void Exit()
        {
            base.Exit();
            _wallJumpTimer.OnFinished -= Start;
        }

        public override void Update()
        {
            TickTimers();
            if (Player.WallCheck.IsOnWall && Player.Inputs.Jump)
                WallJump();
            else if (Player.GroundCheck.IsGrounded)
                Land();
        }

        void TickTimers() => _wallJumpTimer.Tick(deltaTime);

        void WallJump()
        {
            Stop();
            var bounce = _wallJumpBounce;
            var side = (int) Player.WallCheck.WallSide;
            Player.Rigidbody.velocity = new(bounce.x * -side, bounce.y);
            _wallJumpTimer.Set(_wallJumpFreeze);
            _onWallJump.Invoke();
        }

        void Land()
        {
            _onLand.Invoke();
            Player.Transition(Ground);
        }
    }
}