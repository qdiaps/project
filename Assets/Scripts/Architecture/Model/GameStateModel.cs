using System;
using Architecture.FiniteStateMachine;
using Architecture.FiniteStateMachine.States.Game;
using Core;

namespace Architecture.Model
{
    public class GameStateModel
    {
        private readonly GameData _data;
        private readonly Fsm _fsm;

        public GameStateModel(GameData data, Fsm fsm)
        {
            _data = data;
            _fsm = fsm;
            InitFsm();
        }

        public bool SetState(Type typeState)
        {
            if (_fsm.GetState() == typeState)
                return false;
            _fsm.SetState(typeState);
            return true;
        }

        private void InitFsm()
        {
            _fsm.AddState(new Play());
            _fsm.AddState(new Pause());
            _fsm.SetState(typeof(Play));
        }
    }
}