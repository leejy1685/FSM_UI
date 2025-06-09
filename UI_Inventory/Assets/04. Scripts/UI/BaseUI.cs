using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager _uiManager;
    public virtual void Init(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateUI();

}
