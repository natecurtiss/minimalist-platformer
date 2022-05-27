using System;
using UnityEngine;
using static Player.StateID;

namespace Player
{
    [Serializable]
    class Grounded : Move
    {
        [SerializeField] float _jump = 30f;

        public override void Update()
        {
            if (!Player.GroundCheck.IsGrounded)
                Player.Transition(Air);
            else if (Player.Inputs.Jump)
                Jump();
        }

        void Jump()
        {
            Player.Rigidbody.velocity = new(Player.Rigidbody.velocity.x, _jump);
            Player.Transition(Air);
        }
    }
}