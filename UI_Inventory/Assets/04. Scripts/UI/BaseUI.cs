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

    protected abstract UIState GetState();

    public virtual void SetActive(UIState state)
    {
        gameObject.SetActive(GetState() == state);
    }

}
