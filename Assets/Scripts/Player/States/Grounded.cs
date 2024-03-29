﻿using System;
using UnityEngine;
using UnityEngine.Events;
using static MP.Player.StateID;

namespace MP.Player.States
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
            Player.Rigidbody.velocity = new(Player.Rigidbody.velocity.x, _jump);
            Player.GroundCheck.Reset();
            Player.Inputs.ResetJump();
            _onJump.Invoke();
            Player.Transition(Air);
        }
    }
}