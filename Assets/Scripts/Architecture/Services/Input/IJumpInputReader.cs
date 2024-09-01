using System;

namespace Architecture.Services.Input
{
    public interface IJumpInputReader
    {
        event Action OnJump;
    }
}