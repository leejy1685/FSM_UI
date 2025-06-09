using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : BaseUI
{
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

    private Character _player;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);


        _player = GameManager.Instance.Player;
        UpdatePlayerInfo();
        
        //버튼 등록
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }


    protected override UIState GetState()
    {
        return UIState.MainMenu;
    }

    public override void SetActive(UIState state)
    {
        buttons.SetActive(GetState() == state);
    }

    public void UpdatePlayerInfo()
    {
        grade.text = _player.Data.grade;
        name.text = _player.Data.name;
        level.text = _player.Data.level.ToString();
        exp.value = (float)_player.Data.exp / _player.Data.maxExp;
        expText.text = $"{_player.Data.exp} / {_player.Data.maxExp}";
        desc.text = _player.Data.desc;
        gold.text = _player.Data.gold.ToString("C");
    }

    private void OpenStatus()
    {
        _uiManager.ChangeState(UIState.Status);
    }
    private void OpenInventory()
    {
        _uiManager.ChangeState(UIState.Inventory);
    }
}
