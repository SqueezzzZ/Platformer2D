using System;
using System.Collections.Generic;

public class EnemyStateMachine : IStateMachine
{
    private Dictionary<Type, IState> _states = new ();

    public IState CurrentState { get; private set; }

    public void Init(Enemy enemy)
    {
        _states.Add(typeof(PatrolState), new PatrolState(this, enemy, enemy.Mover, enemy.Patroller, enemy.PlayerScaner, enemy.Rotator, enemy.Animator));
        _states.Add(typeof(WaitState), new WaitState(this, enemy, enemy.Animator, enemy.Waiter, enemy.PlayerScaner));
        _states.Add(typeof(ChaseState), new ChaseState(this, enemy, enemy.Mover, enemy.Rotator, enemy.Animator));

        ChangeState<PatrolState>();
    }

    public void ChangeState<T> () where T : IState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out IState newState))
        {
            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}