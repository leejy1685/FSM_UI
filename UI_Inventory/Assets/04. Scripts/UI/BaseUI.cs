using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUIState
{
    public void Enter();
    public void Exit();
    public void UpdateUI();
}

public abstract class BaseUI : MonoBehaviour, IUIState
{
    protected UIManager _uiManager;
    public virtual void Init(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    public virtual void Enter()
    {
        gameObject.SetActive(true);
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public virtual void UpdateUI()
    {
        
    }
}
