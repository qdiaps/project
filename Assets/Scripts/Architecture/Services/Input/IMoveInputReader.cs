using System;
using UnityEngine;

namespace Architecture.Services.Input
{
    public interface IMoveInputReader
    {
        event Action<Vector3> OnMove;
        event Action<Vector3> OnSprintMove;
    }
}