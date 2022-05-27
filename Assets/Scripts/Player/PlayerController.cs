﻿using System.Collections.Generic;
using UnityEngine;
using static Player.StateID;

namespace Player
{
    class PlayerController : MonoBehaviour
    {
        [SerializeField] StateID _starting = Air;
        
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }
        
        [field: SerializeField]
        public Inputs Inputs { get; private set; }
        
        [field: SerializeField]
        public GroundCheck GroundCheck { get; private set; }
        
        [field: SerializeField]
        public WallCheck WallCheck { get; private set; }

        readonly Dictionary<StateID, State> _states = new()
        {
            { Ground, new Grounded() },
            { Air, new Airborne() }
        };

        StateID _current;

        void Start()
        {
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