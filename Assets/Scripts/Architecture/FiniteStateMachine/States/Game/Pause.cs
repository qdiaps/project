using UnityEngine;

namespace Architecture.FiniteStateMachine.States.Game
{
    public class Pause : State
    {
        public override void Enter()
        {
            Debug.Log("Pause Enter");
        }

        public override void Exit()
        {
            Debug.Log("Pause Exit");
        }
    }
}