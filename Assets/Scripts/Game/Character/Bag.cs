using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public Character character;
    public List<LootItem> LootItems = new List<LootItem>();
    [SerializeField] private int SizeX = 4, SizeY = 5, SizeZ = 2;
    [SerializeField] private Transform container;

    public LootItem lootPref;

    public void AddItem(LootItem item)
    {
        Vector3 position;
        position.x = ((LootItems.Count % SizeX * LootItem.outerX ));
        position.y = (Mathf.Ceil((LootItems.Count / (SizeY + SizeX - 1))) * LootItem.outerY);
        position.z = Mathf.Ceil(((LootItems.Count % (SizeX * SizeZ)) / (SizeY - 1))) * LootItem.outerZ; 

        LootItems.Add(item);
        item.Move(position, container);
    }

    public void RemoveItem(LootItem item)
    {
        if (LootItems.Exists(x => x == item))
            LootItems.Remove(item);
    }

    public void RemoveItems(Transform _transform)
    {
        StartCoroutine(IRemoveItems(_transform));
    }

    private IEnumerator IRemoveItems(Transform _transform)
    {
        while (LootItems.Count > 0)
        {
            LootItems.Reverse();
            foreach (var item in LootItems.ToList())
            {
                item.MoveAndDestroy(_transform.position, _transform, () => GameInitializer.instance.wallet.TryAddMoney(item.transform, item.ItemPrice));
                RemoveItem(item);
                character.Inventory.RemoveItem(item);
                yield return new WaitForSeconds(0.06f);
            }
        }
    }
}
