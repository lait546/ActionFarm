using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterAnimation Anim;
    public CharacterMovement Movement;
    public CharacterHarvest Harvest;
    public CharacterInventory Inventory;
    public Bag bag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Loot")
        {
            if (other.gameObject.GetComponent<LootItem>())
            {
                Inventory.AddItem(other.gameObject.GetComponent<LootItem>());
            }
        }
        else if (other.gameObject.tag == "Shop")
        {
            if (other.gameObject.GetComponent<FarmShop>()) //is
            {
                other.gameObject.GetComponent<FarmShop>().SellItems();
            }
        }
    }
}
