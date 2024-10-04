using Architecture.FiniteStateMachine;
using Architecture.FiniteStateMachine.States.Game;
using Architecture.Services.Input;

namespace Architecture.Model.State
{
    public class StateModel : IModel<StateData>
    {
        private readonly Fsm _fsm;
        private readonly IInputControlChanger _inputControlChanger;

        public StateModel(Fsm fsm, IInputControlChanger inputControlChanger)
        {
            _fsm = fsm;
            _inputControlChanger = inputControlChanger;
            InitFsm();
        }

        public StateData Read() => 
            new(_fsm.GetState());

        public void Update(StateData data) => 
            _fsm.SetState(data.State);

        private void InitFsm()
        {
            _fsm.AddState(new Play(_inputControlChanger));
            _fsm.AddState(new Pause(_inputControlChanger));
            _fsm.AddState(new Settings());
            _fsm.AddState(new Learning());
            _fsm.SetState(typeof(Play));
        }
    }
}