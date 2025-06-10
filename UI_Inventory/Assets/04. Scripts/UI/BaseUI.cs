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
        UpdateUI();
        gameObject.SetActive(true);
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public virtual void UpdateUI()
    {
        
    }
    
    protected void StartAnimation(int animationHash)
    {
        _uiManager.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _uiManager.Animator.SetBool(animationHash, false);
    }
}
