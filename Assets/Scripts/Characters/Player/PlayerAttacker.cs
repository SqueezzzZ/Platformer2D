using UnityEngine;

[RequireComponent(typeof(ArrowSpawner))]
public class PlayerAttacker : MonoBehaviour
{
    private ArrowSpawner _arrowSpawner;

    private void Awake()
    {
        _arrowSpawner = GetComponent<ArrowSpawner>();
    }

    public void Shoot()
    {
        _arrowSpawner.SpawnArrow();
    }
}