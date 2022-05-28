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
        [SerializeField] float _groundDetectionDelay = 0.5f;
        [SerializeField, Space] UnityEvent _onLand;
        [SerializeField, Space] UnityEvent _onWallJump;
        
        readonly Timer _wallJumpTimer = new();
        readonly Timer _initialGroundedDelay = new();

        public override void Enter()
        {
            base.Enter();
            _wallJumpTimer.OnFinished += ResumeMovement;
            _initialGroundedDelay.Set(_groundDetectionDelay);
        }

        public override void Exit()
        {
            base.Exit();
            _wallJumpTimer.OnFinished -= ResumeMovement;
        }

        public override void Update()
        {
            TickTimers();
            if (Player.WallCheck.IsOnWall && Player.Inputs.Jump)
                WallJump();
            else if (Player.GroundCheck.IsGrounded && _initialGroundedDelay.IsFinished)
                Land();
        }

        void TickTimers()
        {
            _wallJumpTimer.Tick(deltaTime);
            _initialGroundedDelay.Tick(deltaTime);
        }

        void WallJump()
        {
            PauseMovement();
            var bounce = _wallJumpBounce;
            var side = (int) Player.WallCheck.WallSide;
            Player.Rigidbody.velocity = new(bounce.x * -side, bounce.y);
            _wallJumpTimer.Set(_wallJumpFreeze);
            _onWallJump.Invoke();
            // TODO: Squish on wall jump based on Direction.
        }

        void Land()
        {
            _onLand.Invoke();
            Player.Transition(Ground);
        }
    }
}