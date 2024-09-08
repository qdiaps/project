using UnityEngine;

namespace Architecture.FiniteStateMachine.States.Game
{
    public class Play : State
    {
        public override void Enter()
        {
            Debug.Log("Play Enter");
        }

        public override void Exit()
        {
            Debug.Log("Play Exit");
        }
    }
}