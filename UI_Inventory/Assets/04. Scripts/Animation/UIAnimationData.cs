using System;
using UnityEngine;


//<Summary>
// UI 애니메이션 파라미터를 hash 데이터로 변경하는 클래스
//</Summary>
[Serializable]
public class UIAnimationData
{
    [SerializeField] private string mainMenuParameterName = "@MainMenu";
    [SerializeField] private string statusParameterName = "@Status";
    [SerializeField] private string inventoryParameterName = "@Inventory";
    [SerializeField] private string exitParameterName = "Exit";
    [SerializeField] private string idleParameterName = "Idle";
    
    public int MainMenuParameterHash { get; private set; }
    public int StatusParameterName { get; private set; }
    public int InventoryParameterName { get; private set; }
    public int ExitParameterName { get; private set; }
    public int IdleParameterName { get; private set; }
    

    public void Initialize()
    {
        MainMenuParameterHash = Animator.StringToHash(mainMenuParameterName);
        StatusParameterName = Animator.StringToHash(statusParameterName);
        InventoryParameterName = Animator.StringToHash(inventoryParameterName);
        ExitParameterName = Animator.StringToHash(exitParameterName);
        IdleParameterName = Animator.StringToHash(idleParameterName);
    }
}
