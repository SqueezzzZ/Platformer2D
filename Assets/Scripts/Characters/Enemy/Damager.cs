using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 20;
    [SerializeField] private float _pushPower = 20f;

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(_damageAmount);
    }

    public void HitPlayer(Player player, Vector2 pushDirection)
    {
        player.Push(pushDirection, _pushPower);
    }
}