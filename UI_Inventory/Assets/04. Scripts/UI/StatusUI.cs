using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//<Summary>
//스테이터스 상태
//</Summary>
public class StatusUI : BaseUI
{
    //직렬화
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI crt;
    [SerializeField] private Button backButton;
    
    //필드
    private Character _player;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _player = GameManager.Instance.Player;
        
        //버튼 등록;
        backButton.onClick.AddListener(OpenMainMenu);
    }

    public override async void Enter()
    {
        base.Enter();
        
        //입장 애니메이션
        StartAnimation(_uiManager.AnimationData.StatusParameterName);

        //애니메이션 시간만큼 대기
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
        
        //애니메이션 시간 만큼 대기
        var animLength = _uiManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        //애니메이션 종료
        StopAnimation(_uiManager.AnimationData.StatusParameterName);
        StopAnimation(_uiManager.AnimationData.ExitParameterName);
        
        base.Exit();
    }


    //UI 갱신
    public override void UpdateUI()
    {
        atk.text = _player.Data.atk.ToString() + (_player.EquippedWeapon ? $" (+ {_player.EquippedWeapon.weaponData.atk})" : "");
        crt.text = _player.Data.cri.ToString() + (_player.EquippedWeapon ? $" (+ {_player.EquippedWeapon.weaponData.cri})" : "");
        def.text = _player.Data.def.ToString() + (_player.EquippedArmor ? $" (+ {_player.EquippedArmor.armorData.def})" : "");
        hp.text = _player.Data.hp.ToString() + (_player.EquippedArmor ? $" (+ {_player.EquippedArmor.armorData.hp})" : "");
    }
    
    //상태 변환
    private void OpenMainMenu()
    {
        _uiManager.ChangeState(_uiManager.MainMenuUI);
    }
    
    
    
}
