using System.Collections.Generic;
using MP.Player.Checks;
using MP.Player.States;
using UnityEngine;
using static MP.Player.StateID;

namespace MP.Player
{
    class PlayerController : MonoBehaviour
    {
        [SerializeField] StateID _starting = Air;
        [SerializeField] Grounded _groundedState;
        [SerializeField] Airborne _airborneState;
        
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }
        
        [field: SerializeField]
        public Inputs Inputs { get; private set; }
        
        [field: SerializeField]
        public GroundCheck GroundCheck { get; private set; }
        
        [field: SerializeField]
        public WallCheck WallCheck { get; private set; }

        Dictionary<StateID, State> _states;
        StateID _current;

        void Start()
        {
            _states = new()
            {
                { Ground, _groundedState },
                { Air, _airborneState }
            };
            foreach (var (_, state) in _states) 
                state.Init(this);
            _current = _starting;
            _states[_current].Enter();
        }

        void Update() => _states[_current].Update();
        void FixedUpdate() => _states[_current].FixedUpdate();

        public void Transition(StateID state)
        {
            _states[_current].Exit();
            _states[state].Enter();
            _current = state;
        }
    }
}