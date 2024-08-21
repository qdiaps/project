using System;
using UnityEngine;

namespace Architecture.Services.Input
{
    public interface IInputReader
    {
        event Action<Vector3> OnMove;
        event Action<Vector3> OnSprintMove;
        
        event Action OnJump;
    }
}