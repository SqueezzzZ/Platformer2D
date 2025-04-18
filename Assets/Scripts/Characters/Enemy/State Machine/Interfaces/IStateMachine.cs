using System;

public interface IStateMachine
{
    public void ChangeState<T>() where T : IState;
}
