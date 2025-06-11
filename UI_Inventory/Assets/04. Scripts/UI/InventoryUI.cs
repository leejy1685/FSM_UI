using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//<summary>
//인벤토리 UI 상태
//</summary>
public class InventoryUI : BaseUI
{
    //직렬화
    [SerializeField] private TextMeshProUGUI inventorySize;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject slots;
    [SerializeField] private GameObject slot;
    [SerializeField] private float slotInterval = 5f;

    //필드
    private int _slotCount;
    private List<SlotUI> _slots = new List<SlotUI>();
    private Character _player;
    
    //생성
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _player = GameManager.Instance.Player;
        _slotCount = _player.InventorySize;
        
        //슬롯 생성
        SetSlot();
        
        //버튼 기능 할당
        backButton.onClick.AddListener(OpenMainMenu);
    }
    
    public override async void Enter()
    {
        //오브젝트 활성화
        base.Enter(); 

        //입장 애니메이션
        StartAnimation(_uiManager.AnimationData.InventoryParameterName);

        //애니메이션 시간동안 딜레이
        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        //대기 애니메이션
        StartAnimation(_uiManager.AnimationData.IdleParameterName);
    }
    
    public override async void Exit()
    {
        //퇴장 애니메이션
        StopAnimation(_uiManager.AnimationData.IdleParameterName);
        StartAnimation(_uiManager.AnimationData.ExitParameterName);
        
        //애니메이션 시간동안 딜레이
        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        //애니메이션 현재 상태 종료
        StopAnimation(_uiManager.AnimationData.InventoryParameterName);
        StopAnimation(_uiManager.AnimationData.ExitParameterName);
        
        base.Exit();
    }
    

    //UI 갱신
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
    
    //상태 변경
    private void OpenMainMenu()
    {
        _uiManager.ChangeState(_uiManager.MainMenuUI);
    }
    
    //슬롯 생성, 개선 여지 있음
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
