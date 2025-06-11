using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//<summary>
//메인 메뉴 상태
//</summary>
public class MainMenuUI : BaseUI
{
    //직렬화
    [SerializeField] private TextMeshProUGUI grade;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private Slider exp;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    //필드
    private Character _player;
    
    //생성
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        _player = GameManager.Instance.Player;
        
        //버튼 등록
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }
    
    public override async void Enter()
    {
        //메인 메뉴는 버튼만 활성화
        UpdateUI();
        buttons.SetActive(true);
        
        //입장 애니메이션
        StartAnimation(_uiManager.AnimationData.MainMenuParameterHash);

        //애니메이션 시간 만큼 딜레이
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
        
        //애니메이션 시간만큼 딜레이
        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        //애니메이션 종료
        StopAnimation(_uiManager.AnimationData.MainMenuParameterHash);
        StopAnimation(_uiManager.AnimationData.ExitParameterName);
        
        //메인 메뉴는 버튼만 비활성화
        buttons.SetActive(false);
    }

    //UI 갱신
    public override void UpdateUI()
    {
        grade.text = _player.Data.grade;
        name.text = _player.Data.name;
        level.text = _player.Data.level.ToString();
        exp.value = (float)_player.Data.exp / _player.Data.maxExp;
        expText.text = $"{_player.Data.exp} / {_player.Data.maxExp}";
        desc.text = _player.Data.desc;
        gold.text = string.Format("{0:N0}",_player.Data.gold);
    }

    //상태 변환
    private void OpenStatus()
    {
        _uiManager.ChangeState(_uiManager.StatusUI);
    }
    private void OpenInventory()
    {
        _uiManager.ChangeState(_uiManager.InventoryUI);
    }
}
