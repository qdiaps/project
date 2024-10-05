using System;

namespace Architecture.Services.Input
{
    public interface IScanInputReader
    {
        event Action OnStartScan;
        event Action OnStopScan;
    }
}