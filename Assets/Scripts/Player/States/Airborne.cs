using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using static UnityEngine.Time;

namespace Player
{
    [Serializable]
    class Airborne : Move
    {
        [SerializeField] Vector2 _wallJumpBounce = Vector2.one * 20;
        [SerializeField] float _wallJumpFreeze = 1f;
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
            if (Player.WallCheck.IsOnWall && Player.Inputs.Jump)
                WallJump();
        }

        void TickTimers() => _wallJumpTimer.Tick(deltaTime);

        void WallJump()
        {
            Stop();
            _wallJumpTimer.Set(_wallJumpFreeze);
            Player.Rigidbody.velocity = _wallJumpBounce * (int) Player.WallCheck.WallSide;
            _onWallJump.Invoke();
        }
    }
}