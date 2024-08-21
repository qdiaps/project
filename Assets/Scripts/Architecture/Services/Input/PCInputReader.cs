using System;
using UnityEngine;
using VContainer.Unity;

namespace Architecture.Services.Input
{
    public class PCInputReader : IInputReader, IFixedTickable
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnSprintMove;
        public event Action OnJump;
        
        private const string AxisHorizontal = "Horizontal";
        private const string AxisVertical = "Vertical";

        public void FixedTick()
        {
            ReadMove();
            ReadJump();
        }

        private void ReadMove()
        {
            var velocity = new Vector3(UnityEngine.Input.GetAxis(AxisHorizontal), 0, UnityEngine.Input.GetAxis(AxisVertical));
            if (velocity.x != 0 || velocity.z != 0)
            {
                if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
                {
                    OnSprintMove?.Invoke(velocity);
                    return;
                }

                OnMove?.Invoke(velocity);
            }
        }

        private void ReadJump()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
        }
    }
}