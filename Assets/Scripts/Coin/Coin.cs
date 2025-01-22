using UnityEngine;

public class Coin : MonoBehaviour 
{
    public int Price { get; private set; } = 1;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}