namespace Architecture.FiniteStateMachine.States
{
    public abstract class State
    {
        public virtual void Enter() { }
        
        public virtual void Exit() { }
    }
}