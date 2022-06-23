using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmShop : MonoBehaviour
{
    [SerializeField] private Transform SellPoint;

    public void SellItems()
    {
        GameInitializer.instance.character.bag.RemoveItems(SellPoint);
    }
}
