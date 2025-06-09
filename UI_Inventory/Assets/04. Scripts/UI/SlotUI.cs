using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public ItemData Item { get; private set; }

    [SerializeField] private Image icon;
    [SerializeField] private Image equippedIcon;

    public Button EquipButton { get; private set; }

    private void Awake()
    {
        EquipButton = icon.GetComponent<Button>();
        EquipButton.onClick.AddListener(OnClickEquipButton);
    }

    public void SetItem(ItemData item)
    {
        Item = item;
        
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
    }

    public void RefreshUI()
    {
        Item = null;
        
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
    
    void OnClickEquipButton()
    {
        if(!equippedIcon.gameObject.activeSelf)
            GameManager.Instance.EquipItem(Item);
        else
            GameManager.Instance.UnequipItem(Item);
    }

    public void SetEquippedIcon(bool isEquipped)
    {
        equippedIcon.gameObject.SetActive(isEquipped);
    }
}
