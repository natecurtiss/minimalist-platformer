using System;
using MP.Utils;
using UnityEngine;
using UnityEngine.Events;
using static MP.Player.StateID;
using static UnityEngine.Time;

namespace MP.Player.States
{
    [Serializable]
    class Airborne : Move
    {
        [SerializeField] Vector2 _wallJumpBounce = Vector2.one * 20;
        [SerializeField] float _wallJumpFreeze = 1f;
        [SerializeField] float _wallJumpCooldown = 0.5f;
        [SerializeField] float _groundDetectionDelayOnStart = 0.1f;
        [SerializeField, Space] UnityEvent _onLand;
        [SerializeField, Space] UnityEvent _onWallJump;
        
        readonly Timer _wallJumpFreezeTimer = new();
        readonly Timer _wallJumpCooldownTimer = new();
        readonly Timer _initialGroundedDelay = new();

        public override void Enter()
        {
            base.Enter();
            _wallJumpFreezeTimer.OnFinished += ResumeMovement;
            _initialGroundedDelay.Set(_groundDetectionDelayOnStart);
        }

        public override void Exit()
        {
            base.Exit();
            _wallJumpFreezeTimer.OnFinished -= ResumeMovement;
        }

        public override void Update()
        {
            TickTimers();
            if (Player.GroundCheck.IsGrounded && _initialGroundedDelay.IsFinished)
                Land();
            else if (Player.WallCheck.IsOnWall && Player.Inputs.Jump && _wallJumpCooldownTimer.IsFinished)
                WallJump();
        }

        void TickTimers()
        {
            _wallJumpFreezeTimer.Tick(deltaTime);
            _wallJumpCooldownTimer.Tick(deltaTime);
            _initialGroundedDelay.Tick(deltaTime);
        }

        void WallJump()
        {
            PauseMovement();
            var bounce = _wallJumpBounce;
            var side = (int) Player.WallCheck.WallSide;
            Player.Rigidbody.velocity = new(bounce.x * -side, bounce.y);
            _wallJumpFreezeTimer.Set(_wallJumpFreeze);
            _wallJumpCooldownTimer.Set(_wallJumpCooldown);
            _onWallJump.Invoke();
        }

        void Land()
        {
            _onLand.Invoke();
            Player.Transition(Ground);
        }
    }
}