using UnityEngine;
using static UnityEngine.Mathf;

namespace Player
{
    abstract class Move : State
    {
        [field: SerializeField] 
        protected float Speed { get; private set; }
        [field: SerializeField] 
        protected float Acceleration { get; private set; }
        [field: SerializeField] 
        protected float Deceleration { get; private set; }
        
        protected PlayerController Player { get; private set; }

        public override void Init(PlayerController player) => Player = player;

        public override void FixedUpdate()
        {
            var target = Speed * Player.Inputs.Horizontal;
            var t = target == 0 ? Deceleration : Acceleration;
            var lerp = Lerp(Player.Rigidbody.velocity.x, target, t);
            Player.Rigidbody.velocity = new(lerp, Player.Rigidbody.velocity.y);
        }
    }
}