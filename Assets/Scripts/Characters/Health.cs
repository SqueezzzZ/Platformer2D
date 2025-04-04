using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int Amount { get; private set; }

    public event Action Ended;
    public event Action<int> Changed;

    private void Awake()
    {
        Amount = _maxHealth;
    }

    public void Add(int amount)
    {
        if (amount <= 0)
            return;

        if (amount + Amount > _maxHealth)
            amount = _maxHealth - Amount;

        Amount += amount;
        Changed?.Invoke(amount);
    }

    public void Take(int amount)
    {
        if (amount <= 0)
            return;

        if (amount > Amount)
            amount = Amount;

        Amount -= amount;
        Changed?.Invoke(amount);

        if (Amount == 0)
            Ended?.Invoke();
    }
}