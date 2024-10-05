using Architecture.Services.Input;
using UnityEngine;

namespace Architecture.FiniteStateMachine.States.Game
{
    public class Play : State
    {
        private readonly IInputControlChanger _inputControlChanger;

        public Play(IInputControlChanger inputControlChanger) => 
            _inputControlChanger = inputControlChanger;

        public override void Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            _inputControlChanger.ChangeInputControl(InputControlType.Gameplay);
        }

        public override void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            _inputControlChanger.ChangeInputControl(InputControlType.None);
        }
    }
}