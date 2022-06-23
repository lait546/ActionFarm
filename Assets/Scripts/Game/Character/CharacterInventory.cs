using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Character character;
    public const int MAX_ITEM_COUNT = 11;
    public int CountWeast = 0;
    public GameObject scythe;

    public Action<int, int> OnChangeCountItems;
    public Action<string> OnFullInventory;

    public void AddItem(LootItem item)
    {
        if (CountWeast < MAX_ITEM_COUNT)
        {
            character.bag.AddItem(item);
            CountWeast += item.ItemValue;

            OnChangeCountItems?.Invoke(CountWeast, MAX_ITEM_COUNT);
        }
        else
        {
            OnFullInventory?.Invoke("Inventory is full");
        }
    }

    public void RemoveItem(LootItem item)
    {
        CountWeast -= 1;
        OnChangeCountItems?.Invoke(CountWeast, MAX_ITEM_COUNT);
    }
}
