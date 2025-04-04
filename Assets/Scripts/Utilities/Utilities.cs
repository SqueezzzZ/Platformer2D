using UnityEngine;

static class Utilities
{
    public static bool IsEnoughDistance(Vector3 thisPoint, Vector3 targetPoint, float distance)
    {
        return (targetPoint - thisPoint).sqrMagnitude <= distance * distance;
    }
}
