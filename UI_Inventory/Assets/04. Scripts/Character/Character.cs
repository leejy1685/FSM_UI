using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData Data { get; private set; }
    public List<ItemData> Inventory { get; private set; }

    public void SetData(CharacterData data, ItemData[] itemData = null)
    {
        Data = data;

        if (itemData == null)
            return;
        
        Inventory = new List<ItemData>(itemData);
    }

    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }
    
    public void Equip(ItemData item)
    {
        
    }

    public void Unequip(ItemData item)
    {
        
    }
}
