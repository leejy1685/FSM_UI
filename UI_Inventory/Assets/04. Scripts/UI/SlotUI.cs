using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//<Summary>
//아이템 슬롯
//</Summary>
public class SlotUI : MonoBehaviour
{
    //직렬화
    [SerializeField] private Image icon;
    [SerializeField] private Image equippedIcon;

    //프로퍼티
    public ItemData Item { get; private set; }
    public Button EquipButton { get; private set; }

    private void Awake()
    {
        EquipButton = icon.GetComponent<Button>();
        EquipButton.onClick.AddListener(OnClickEquipButton);
    }

    //아이템 셋팅
    public void SetItem(ItemData item)
    {
        Item = item;
        
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
    }

    //아이템 비우기
    public void RefreshUI()
    {
        Item = null;
        
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
    
    //클릭 시 아이템 장착 또는 해제
    void OnClickEquipButton()
    {
        if(!equippedIcon.gameObject.activeSelf)
            GameManager.Instance.EquipItem(Item);
        else
            GameManager.Instance.UnequipItem(Item);
    }

    //장착 아이콘 표시
    public void SetEquippedIcon(bool isEquipped)
    {
        equippedIcon.gameObject.SetActive(isEquipped);
    }
}
