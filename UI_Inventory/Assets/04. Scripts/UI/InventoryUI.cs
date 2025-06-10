using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI inventorySize;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject slots;
    [SerializeField] private GameObject slot;

    [SerializeField] private float slotInterval = 5f;

    private int _slotCount;
    private List<SlotUI> _slots = new List<SlotUI>();
    private Character _player;
    
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _player = GameManager.Instance.Player;
        _slotCount = _player.InventorySize;
        
        SetSlot();
        
        backButton.onClick.AddListener(OpenMainMenu);
    }

    public override async void Enter()
    {
        base.Enter();

        StartAnimation(_uiManager.AnimationData.InventoryParameterName);

        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        StartAnimation(_uiManager.AnimationData.IdleParameterName);
    }
    
    public override async void Exit()
    {
        StopAnimation(_uiManager.AnimationData.IdleParameterName);
        StartAnimation(_uiManager.AnimationData.ExitParameterName);
        
        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        StopAnimation(_uiManager.AnimationData.InventoryParameterName);
        StopAnimation(_uiManager.AnimationData.ExitParameterName);

        
        base.Exit();
    }
    

    public override void UpdateUI()
    {
        inventorySize.text = $"{_player.Inventory.Count} / {_slotCount}";
        
        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < _player.Inventory.Count)
                _slots[i].SetItem(_player.Inventory[i]);
            
            if(_player.EquippedWeapon == _slots[i].Item && _slots[i].Item != null) 
                _slots[i].SetEquippedIcon(true);
            else if(_player.EquippedArmor == _slots[i].Item && _slots[i].Item != null)
                _slots[i].SetEquippedIcon(true);
            else
                _slots[i].SetEquippedIcon(false);
        }
    }
    private void OpenMainMenu()
    {
        _uiManager.ChangeState(_uiManager.MainMenuUI);
    }
    
    //개선 여지
    private void SetSlot()
    {
        //슬록의 사이즈 구하기
        RectTransform size = slot.GetComponent<RectTransform>();
        float width = size.rect.width;
        float height = size.rect.height;

        //스크롤 뷰 사이즈 변경
        RectTransform slotsRect = slots.GetComponent<RectTransform>();
        Vector2 slotsSize = slotsRect.sizeDelta;
        float slotsHeight = (height+slotInterval) * (_slotCount / 3);
        slotsRect.sizeDelta = new Vector2(slotsSize.x, slotsHeight);
        
        for (int i = 0; i < _slotCount; i++)
        {
            //슬롯 배치
            GameObject go = Instantiate(slot,slots.transform);
            float x = (width + slotInterval) * (i % 3);
            float y = -((height + slotInterval) * (i / 3));
            
            go.transform.localPosition = new Vector2(x, y);

            //아이템 배치
            SlotUI slotUI = go.GetComponent<SlotUI>();
            if (i < _player.Inventory.Count)
                slotUI.SetItem(_player.Inventory[i]);
            
            _slots.Add(slotUI);
        }
    }
}
