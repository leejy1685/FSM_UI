using System;
using UnityEngine;


//아이템 타입 이넘, 장착 아이템 종류가 늘어난다면, interface로 구현해도 될듯.
public enum ItemType
{
    Weapon,
    Armor,
}

//무기 데이터
[Serializable]
public class WeaponData
{
    public int atk;
    public int cri;
}

//방어구 데이터
[Serializable]
public class ArmorData
{
    public int def;
    public int hp;
}



//<summary>
//아이템의 정보를 담는 클래스
//</summary>
[CreateAssetMenu (fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("ItemInfo")]
    public ItemType type;
    public WeaponData weaponData;
    public ArmorData armorData;
    
    [Header("ItemImage")]
    public Sprite icon;
}
