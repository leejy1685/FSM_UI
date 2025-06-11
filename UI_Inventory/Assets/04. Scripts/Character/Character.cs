using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//<Summary>
//캐릭터의 데이터를 받아 실제 캐릭터 역할을 하는 클래스
//</Summary>
public class Character : MonoBehaviour
{
    //직렬화
    [SerializeField] private int inventorySize;

    //프로퍼티
    public CharacterData Data { get; private set; }
    public List<ItemData> Inventory { get; private set; }
    public ItemData EquippedWeapon { get; private set; }
    public ItemData EquippedArmor { get; private set; }
    public int InventorySize { get => inventorySize; }

    //데이터를 받는 메서드
    public void SetData(CharacterData data, ItemData[] itemData = null)
    {
        Data = data;

        if (itemData == null)
            return;

        Inventory = new List<ItemData>(itemData);
    }

    //인벤토리에 아이템 추가
    public void AddItem(ItemData item)
    {
        if(inventorySize > Inventory.Count)
            Inventory.Add(item);
    }

    //아이템 장착
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

    //아이템 장착 해제
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