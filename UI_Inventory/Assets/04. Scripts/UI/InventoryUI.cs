using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private Button backButton;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        backButton.onClick.AddListener(OnClickBackButton);
    }

    protected override UIState GetState()
    {
        return UIState.Inventory;
    }

    private void OnClickBackButton()
    {
        _uiManager.ChangeState(UIState.MainMenu);
    }
}
