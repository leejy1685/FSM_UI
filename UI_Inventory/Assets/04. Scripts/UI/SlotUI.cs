using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    private ItemData _item;
    
    [SerializeField] private Image icon;
    [SerializeField] private Image equippedIcon;
    
    public void SetItem(ItemData item)
    {
        _item = item;
        
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
    }

    public void RefreshUI()
    {
        _item = null;
        
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
}
