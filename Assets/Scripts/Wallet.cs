using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public void AddCoins(int amount)
    {
        if (amount <= 0)
            return;

        _coins += amount;
    }
}
