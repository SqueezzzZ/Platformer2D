using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
        }
    }
}