using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIAnimationData
{
    [SerializeField] private string mainMenuParameterName = "@MainMenu";
    [SerializeField] private string statusParameterName = "@Status";
    [SerializeField] private string inventoryParameterName = "@Inventory";
    [SerializeField] private string enterParameterName = "Enter";
    [SerializeField] private string exitParameterName = "Exit";
    [SerializeField] private string idleParameterName = "Idle";
    
    public int MainMenuParameterHash { get; private set; }
    public int StatusParameterName { get; private set; }
    public int InventoryParameterName { get; private set; }
    public int EnterParameterName { get; private set; }
    public int ExitParameterName { get; private set; }
    public int IdleParameterName { get; private set; }
    

    public void Initialize()
    {
        MainMenuParameterHash = Animator.StringToHash(mainMenuParameterName);
        StatusParameterName = Animator.StringToHash(statusParameterName);
        InventoryParameterName = Animator.StringToHash(inventoryParameterName);
        EnterParameterName = Animator.StringToHash(enterParameterName);
        ExitParameterName = Animator.StringToHash(exitParameterName);
        IdleParameterName = Animator.StringToHash(idleParameterName);
    }
}
