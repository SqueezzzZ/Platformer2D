using UnityEngine;
using UnityEngine.Pool;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab;

    private ObjectPool<Arrow> _arrowPool;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;
    private int _arrowLifetime = 3;

    private void Awake()
    {
        _arrowPool = new ObjectPool<Arrow>(
            createFunc: () => InstantiateArrow(),
            actionOnGet: (arrow) => ActionOnGet(arrow),
            actionOnRelease: (arrow) => arrow.SetActive(false),
            actionOnDestroy: (arrow) => DestroyArrow(arrow),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void SpawnArrow()
    {
        _arrowPool.Get();
    }

    private Arrow InstantiateArrow()
    {
        Arrow arrow = Instantiate(_arrowPrefab, transform.position, transform.rotation);

        arrow.Collided += OnCollided;
        arrow.LifeTimeEnded += OnLifetimeEnded;
        return arrow;
    }

    private void ActionOnGet(Arrow arrow)
    {
        Initalize(arrow);
    }

    private void DestroyArrow(Arrow arrow)
    {
        arrow.Collided -= OnCollided;
        arrow.LifeTimeEnded -= OnLifetimeEnded;
        Destroy(arrow.gameObject);
    }

    private void OnCollided(Arrow arrow)
    {
        _arrowPool.Release(arrow);
    }

    private void OnLifetimeEnded(Arrow arrow)
    {
        _arrowPool.Release(arrow);
    }

    private void Initalize(Arrow arrow)
    {
        arrow.SetPosition(transform.position);
        arrow.SetRotation(transform.rotation);
        arrow.SetActive(true);
        arrow.StartLifetimeCoroutine(_arrowLifetime);
    }
}