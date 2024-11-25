using System;
using UnityEngine;

public class RoutePointTrigger : MonoBehaviour
{
    public event Action TriggerEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RoutePoint>())
        {
            TriggerEntered?.Invoke();
        }
    }
}