using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
}

[Serializable]
public class WeaponData
{
    public int atk;
    public int cri;
}

[Serializable]
public class ArmorData
{
    public int def;
    public int hp;
}


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
