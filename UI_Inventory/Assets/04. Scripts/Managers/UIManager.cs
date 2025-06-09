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
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("UIManager").AddComponent<UIManager>();
            }

            return _instance;
        }
    }
    
    private UIState _currentState;
    
    private MainMenuUI _mainMenuUI;
    private StatusUI _statusUI;
    private InventoryUI _inventoryUI;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }


    }
    private void Start()
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
