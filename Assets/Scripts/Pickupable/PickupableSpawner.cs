using UnityEngine;

public class PickupableSpawner : MonoBehaviour
{
    [SerializeField] private Pickupable _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        Spawn();
    }

    public void OnCollected(Pickupable pickupable)
    {
        pickupable.Collected -= OnCollected;
        Destroy(pickupable.gameObject);
    }

    private void Spawn()
    {
        Pickupable pickupable;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            pickupable = Instantiate(_prefab, _spawnPoints[i].position, Quaternion.identity);

            pickupable.Collected += OnCollected;
        }
    }
}