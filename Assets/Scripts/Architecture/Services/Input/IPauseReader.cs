using System;

namespace Architecture.Services.Input
{
    public interface IPauseReader
    {
        event Action OnPauseEnter;
        event Action OnPauseExit;
    }
}