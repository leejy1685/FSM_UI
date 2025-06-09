using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI crt;

    [SerializeField] private Button backButton;
    
    
    private Character _player;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        _player = GameManager.Instance.Player;
        
        //버튼 등록;
        backButton.onClick.AddListener(OpenMainMenu);
    }

    public override void Enter()
    {
        UpdateUI();
        gameObject.SetActive(true);
    }
    
    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    public override void UpdateUI()
    {
        atk.text = _player.Data.atk.ToString() + (_player.EquippedWeapon ? $" (+ {_player.EquippedWeapon.weaponData.atk})" : "");
        crt.text = _player.Data.cri.ToString() + (_player.EquippedWeapon ? $" (+ {_player.EquippedWeapon.weaponData.cri})" : "");
        def.text = _player.Data.def.ToString() + (_player.EquippedArmor ? $" (+ {_player.EquippedArmor.armorData.def})" : "");
        hp.text = _player.Data.hp.ToString() + (_player.EquippedArmor ? $" (+ {_player.EquippedArmor.armorData.hp})" : "");
    }
    
    private void OpenMainMenu()
    {
        _uiManager.ChangeState(_uiManager.MainMenuUI);
    }
    
    
}
