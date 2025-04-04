using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

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
        return arrow;
    }

    private void ActionOnGet(Arrow arrow)
    {
        arrow.SetPosition(transform.position);
        arrow.SetRotation(transform.rotation);
        arrow.SetActive(true);
        arrow.SetLifetimeCoroutine(StartCoroutine(ReleaseArrowDelayed(arrow)));
    }

    private void DestroyArrow(Arrow arrow)
    {
        arrow.Collided -= OnCollided;
        arrow.Destroy();
    }

    private IEnumerator ReleaseArrowDelayed(Arrow arrow)
    {
        yield return new WaitForSeconds(_arrowLifetime);
        _arrowPool.Release(arrow);
    }

    private void OnCollided(Arrow arrow)
    {
        _arrowPool.Release(arrow);
    }
}