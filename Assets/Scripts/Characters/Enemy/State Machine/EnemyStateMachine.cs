public class EnemyStateMachine
{
    public State CurrentState { get; private set; }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Init(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    } 
}