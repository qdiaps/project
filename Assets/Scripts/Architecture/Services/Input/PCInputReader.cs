using System;
using UnityEngine;
using VContainer.Unity;

namespace Architecture.Services.Input
{
    public class PCInputReader : IJumpInputReader, IMoveInputReader, IFixedTickable, IStartable, IDisposable
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnSprintMove;
        public event Action OnJump;
        
        private InputControls _inputControls;
        private bool _isSprint;

        public void Start()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            RegisterInputAction();
        }

        public void Dispose() => 
            _inputControls.Disable();

        public void FixedTick() => 
            ReadMove();

        private void ReadMove()
        {
            var input = _inputControls.Gameplay.Move.ReadValue<Vector2>();
            var velocity = new Vector3(input.x, 0, input.y);
            if (velocity.x != 0 || velocity.z != 0)
            {
                if (_isSprint)
                {
                    OnSprintMove?.Invoke(velocity);
                    return;
                }

                OnMove?.Invoke(velocity);
            }
        }

        private void RegisterInputAction()
        {
            _inputControls.Gameplay.Jump.performed += _ => Jump();
            _inputControls.Gameplay.SprintMove.started += _ => SetSprintValue(true);
            _inputControls.Gameplay.SprintMove.canceled += _ => SetSprintValue(false);
        }

        private void Jump() => 
            OnJump?.Invoke();

        private void SetSprintValue(bool value) =>
            _isSprint = value;
    }
}