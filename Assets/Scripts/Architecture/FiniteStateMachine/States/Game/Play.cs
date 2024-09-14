using UnityEngine;

namespace Architecture.FiniteStateMachine.States.Game
{
    public class Play : State
    {
        public override void Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        public override void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}