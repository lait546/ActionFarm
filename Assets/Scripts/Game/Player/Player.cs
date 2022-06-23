using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int Money { get; private set; }

    public event Action<int> OnChangeMoney;

    public void Init()
    {
        instance = this;
    }

    public void AddMoney(int value)
    {
        Money += value;
        OnChangeMoney?.Invoke(Money);
    }

    public void RemoveMoney(int value)
    {
        Money -= value;
        OnChangeMoney?.Invoke(Money);
    }
}
