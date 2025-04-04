using UnityEngine;
using System;

public class PlayerScaner : MonoBehaviour
{
    [SerializeField] private float _detectionRange;
    [SerializeField] private LayerMask _playerLayerMask;

    public bool IsPlayerInView()
    {
        RaycastHit2D raycastHit;

        raycastHit = Physics2D.Raycast(transform.position, transform.right, _detectionRange, _playerLayerMask);

        Debug.DrawRay(transform.position, transform.right * _detectionRange, Color.red, Time.fixedDeltaTime);

        if (raycastHit.transform == null || raycastHit.collider.TryGetComponent(out Player player) == false)
            return false;

        return true;
    }
}