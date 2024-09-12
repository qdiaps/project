using Architecture.FiniteStateMachine;
using Architecture.FiniteStateMachine.States.Game;

namespace Architecture.Model.State
{
    public class StateModel : IModel<StateData>
    {
        private readonly Fsm _fsm;

        public StateModel(Fsm fsm)
        {
            _fsm = fsm;
            InitFsm();
        }

        public StateData Read() => 
            new(_fsm.GetState());

        public void Update(StateData data) => 
            _fsm.SetState(data.State);

        private void InitFsm()
        {
            _fsm.AddState(new Play());
            _fsm.AddState(new Pause());
            _fsm.SetState(typeof(Play));
        }
    }
}