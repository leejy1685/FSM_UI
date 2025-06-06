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

        UpdateStatus();
        
        //버튼 등록;
        backButton.onClick.AddListener(OnClickBackButton);
    }

    protected override UIState GetState()
    {
        return UIState.Status;
    }

    public void UpdateStatus()
    {
        atk.text = _player.atk.ToString();
        def.text = _player.def.ToString();
        hp.text = _player.hp.ToString();
        crt.text = _player.cri.ToString();
    }
    
    private void OnClickBackButton()
    {
        _uiManager.ChangeState(UIState.MainMenu);
    }
    
    
}
