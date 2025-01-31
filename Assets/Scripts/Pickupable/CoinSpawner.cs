using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Pickupable _coinPrefab;
    [SerializeField] private Transform[] _coinSpawnPoints;

    private void Start()
    {
        Spawn();
    }

    public void OnCollected(Pickupable pickupable)
    {
        pickupable.Collected -= OnCollected;
        pickupable.Destroy();
    }

    private void Spawn()
    {
        Pickupable pickupable;

        for (int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            pickupable = Instantiate(_coinPrefab, _coinSpawnPoints[i].position, Quaternion.identity);

            pickupable.Collected += OnCollected;
        }
    }
}