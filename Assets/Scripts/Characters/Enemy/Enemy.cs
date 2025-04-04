using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Waiter))]
[RequireComponent(typeof(PlayerScaner))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Damager))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    private EnemyMover _enemyMover;
    private PlayerScaner _playerScaner;
    private Patroller _patroller;
    private Waiter _waiter;
    private Rotator _rotator;
    private Health _health;
    private CharacterAnimator _animator;
    private EnemyStateMachine _stateMachine;
    private Damager _damager;

    public PatrolState PatrolState { get; private set; }
    public WaitState WaitState { get; private set; } 
    public ChaseState ChaseState { get; private set; }

    public float ChasingMovingSpeed { get; private set; } = 1.4f;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _playerScaner = GetComponent<PlayerScaner>();
        _patroller = GetComponent<Patroller>();
        _waiter = GetComponent<Waiter>();
        _rotator = GetComponent<Rotator>();
        _health = GetComponent<Health>();
        _animator = GetComponent<CharacterAnimator>();
        _damager = GetComponent<Damager>();

        _stateMachine = new EnemyStateMachine();
        PatrolState = new PatrolState(this, _stateMachine, _player, _enemyMover, _patroller, _playerScaner, _rotator, _animator);
        WaitState = new WaitState(this, _stateMachine, _player, _animator, _waiter);
        ChaseState = new ChaseState(this, _player, _stateMachine, _enemyMover, _rotator, _animator);
    }

    private void OnEnable()
    {
        _health.Ended += OnHealthEnded;
    }

    private void OnDisable()
    {
        _health.Ended -= OnHealthEnded;
    }

    private void Start()
    {
        _stateMachine.Init(PatrolState);
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            Vector2 hitDirection = (collision.transform.position - transform.position).normalized;

            _damager.DamagePlayer(player);
            _damager.HitPlayer(player, hitDirection);
        }
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void Damage(int damageAmount)
    {
        _health.Take(damageAmount);
    }

    private void OnHealthEnded()
    {
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    } 
}