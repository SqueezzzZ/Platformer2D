using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _coinSpawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            Instantiate(_coinPrefab, _coinSpawnPoints[i].position, Quaternion.identity);
        }
    }
}