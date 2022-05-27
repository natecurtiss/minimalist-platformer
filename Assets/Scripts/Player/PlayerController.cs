using UnityEngine;

namespace Player
{
    class PlayerController : MonoBehaviour
    {
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField]
        public Inputs Inputs { get; private set; }
        [field: SerializeField]
        public GroundCheck GroundCheck { get; private set; }
        [field: SerializeField]
        public WallCheck WallCheck { get; private set; }

        State[] _states =
        {
            
        };
    }
}