using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    MainMenu,
    Status,
    Inventory
}
    
    
public class UIManager : MonoBehaviour
{
    private UIState _currentState;
    
    private MainMenuUI _mainMenuUI;
    private StatusUI _statusUI;
    private InventoryUI _inventoryUI;

    private void Awake()
    {
        _mainMenuUI = GetComponentInChildren<MainMenuUI>(true);
        _mainMenuUI.Init(this);
        _statusUI = GetComponentInChildren<StatusUI>(true);
        _statusUI.Init(this);
        _inventoryUI = GetComponentInChildren<InventoryUI>(true);
        _inventoryUI.Init(this);

        ChangeState(UIState.MainMenu);
    }

    public void ChangeState(UIState state)
    {
        _currentState = state;
        
        _mainMenuUI.SetActive(_currentState);
        _statusUI.SetActive(_currentState);
        _inventoryUI.SetActive(_currentState);
    }
}
