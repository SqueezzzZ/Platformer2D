public class WaitState : IState
{
    private IStateMachine _stateMachine;
    private Enemy _enemy;
    private CharacterAnimator _animator;
    private Waiter _waiter;
    private PlayerScaner _scaner;

    public WaitState(IStateMachine stateMachine, Enemy enemy, CharacterAnimator animator, Waiter waiter, PlayerScaner scaner)
    {
        _stateMachine = stateMachine;
        _enemy = enemy;
        _animator = animator;
        _waiter = waiter;
        _scaner = scaner;
    }

    public void Enter()
    {
        _animator.SetIdleAnimation();
        _waiter.StartWaiting();
    }

    public void Exit() { }

    public void Update() 
    { 
        if(_scaner.TryGetPlayerInRadius(_waiter.MinDistaceToAttack, out Player player))
        {
            _enemy.SetTargetPlayer(player);
            _stateMachine.ChangeState<ChaseState>();
            return;
        }

        if(_waiter.CanStopWaiting())
        {
            _stateMachine.ChangeState<PatrolState>();
            _enemy.SetTargetPlayer(null);
        }
    }

    public void FixedUpdate() { }
}