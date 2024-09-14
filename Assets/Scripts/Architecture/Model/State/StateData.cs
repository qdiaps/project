using System;

namespace Architecture.Model.State
{
    public class StateData
    {
        public Type State { get; private set; }
        
        public StateData(Type state) => 
            State = state;
    }
}