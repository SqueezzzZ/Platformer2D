using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Pickupable : MonoBehaviour
{
    public event Action<Pickupable> Collected;

    public virtual void Collect()
    {
        Collected?.Invoke(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
