using System;
using UnityEngine;
using UnityEngine.Events;
using static Player.StateID;

namespace Player
{
    [Serializable]
    class Grounded : Move
    {
        [SerializeField] float _jump = 30f;
        [SerializeField, Space] UnityEvent _onJump;
        [SerializeField] UnityEvent _onFall;

        public override void Update()
        {
            if (!Player.GroundCheck.IsGrounded)
                Fall();
            else if (Player.Inputs.Jump)
                Jump();
        }

        void Fall()
        {
            _onFall.Invoke();
            Player.Transition(Air);
        }

        void Jump()
        {
            Player.GroundCheck.Reset();
            Player.Inputs.ResetJump();
            Player.Rigidbody.velocity = new(Player.Rigidbody.velocity.x, _jump);
            _onJump.Invoke();
            Player.Transition(Air);
        }
    }
}