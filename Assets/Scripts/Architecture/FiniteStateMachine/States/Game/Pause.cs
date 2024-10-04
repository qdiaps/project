using Architecture.Services.Input;

namespace Architecture.FiniteStateMachine.States.Game
{
    public class Pause : State
    {
        private readonly IInputControlChanger _inputControlChanger;

        public Pause(IInputControlChanger inputControlChanger) => 
            _inputControlChanger = inputControlChanger;

        public override void Enter() => 
            _inputControlChanger.ChangeInputControl(InputControlType.UI);

        public override void Exit() => 
            _inputControlChanger.ChangeInputControl(InputControlType.None);
    }
}