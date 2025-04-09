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
    private Health _health;
    private EnemyStateMachine _stateMachine;

    public EnemyMover Mover { get; private set; }
    public PlayerScaner PlayerScaner { get; private set; }
    public Patroller Patroller { get; private set; }
    public Waiter Waiter { get; private set; }
    public Rotator Rotator { get; private set; }
    public CharacterAnimator Animator { get; private set; }
    public Damager Damager { get; private set; }

    public Player TargetPlayer { get; private set; }

    private void Awake()
    {
        Mover = GetComponent<EnemyMover>();
        PlayerScaner = GetComponent<PlayerScaner>();
        Patroller = GetComponent<Patroller>();
        Waiter = GetComponent<Waiter>();
        Rotator = GetComponent<Rotator>();
        Animator = GetComponent<CharacterAnimator>();
        Damager = GetComponent<Damager>();

        _health = GetComponent<Health>();
        _stateMachine = new ();
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
        SetTargetPlayer(null);
        _stateMachine.Init(this);
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

            Damager.DamagePlayer(player);
            Damager.HitPlayer(player, hitDirection);
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

    public void SetTargetPlayer(Player targetPlayer)
    {
        TargetPlayer = targetPlayer;
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