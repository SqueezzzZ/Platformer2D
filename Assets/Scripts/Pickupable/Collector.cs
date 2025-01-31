using UnityEngine;
using System;

public class Collector : MonoBehaviour
{
    public event Action<Pickupable> PickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Pickupable pickupable))
        {
            PickedUp?.Invoke(pickupable);
        }
    }
}