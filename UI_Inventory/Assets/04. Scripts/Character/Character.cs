using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int inventorySize;

    public CharacterData Data { get; private set; }
    public List<ItemData> Inventory { get; private set; }
    public ItemData EquippedWeapon { get; private set; }
    public ItemData EquippedArmor { get; private set; }
    public int InventorySize { get => inventorySize; }

    public void SetData(CharacterData data, ItemData[] itemData = null)
    {
        Data = data;

        if (itemData == null)
            return;

        Inventory = new List<ItemData>(itemData);
    }

    public void AddItem(ItemData item)
    {
        if(inventorySize > Inventory.Count)
            Inventory.Add(item);
    }

    public void Equip(ItemData item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                if (EquippedWeapon != null)
                    Unequip(ItemType.Weapon);
                EquippedWeapon = item;
                Data.atk += item.weaponData.atk;
                Data.cri += item.weaponData.cri;
                break;
            case ItemType.Armor:
                if (EquippedArmor != null)
                    Unequip(ItemType.Armor);
                EquippedArmor = item;
                Data.def += item.armorData.def;
                Data.hp += item.armorData.hp;
                break;
        }
    }

    public void Unequip(ItemType type)
    {
        switch (type)
        {
            case ItemType.Weapon:
                Data.atk -= EquippedWeapon.weaponData.atk;
                Data.cri -= EquippedWeapon.weaponData.cri;
                EquippedWeapon = null;
                break;
            case ItemType.Armor:
                Data.def -= EquippedArmor.armorData.def;
                Data.hp -= EquippedArmor.armorData.hp;
                EquippedArmor = null;
                break;
        }
    }
}