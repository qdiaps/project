using System;
using System.Collections.Generic;
using Architecture.FiniteStateMachine.States;
using UnityEngine;

namespace Architecture.FiniteStateMachine
{
    public class Fsm
    {
        private readonly Dictionary<Type, State> _states = new();
        
        private State _currentState;

        public void AddState(State state)
        {
            if (_states.ContainsKey(state.GetType()))
            {
                Debug.LogWarning("State already added");
                return;
            }
            _states.Add(state.GetType(), state);
        }

        public Type GetState() => 
            _currentState?.GetType();

        public void SetState(Type typeState)
        {
            if (_currentState?.GetType() == typeState)
            {
                Debug.LogWarning("typeState already set");
                return;
            }
            else if (_states.ContainsKey(typeState) == false)
            {
                Debug.LogWarning("typeState not added");
                return;
            }
            _currentState?.Exit();
            _currentState = _states[typeState];
            _currentState.Enter();
        }
    }
}