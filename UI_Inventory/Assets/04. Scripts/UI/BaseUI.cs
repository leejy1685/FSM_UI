using UnityEngine;

//UI의 상태를 나타내는 인터페이스
interface IUIState
{
    public void Enter();
    public void Exit();
    public void UpdateUI();
}


//UI의 상태의 기본이 되는 클래스
public abstract class BaseUI : MonoBehaviour, IUIState
{
    //생성
    protected UIManager _uiManager;
    public virtual void Init(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    //입장
    public virtual void Enter()
    {
        UpdateUI();
        gameObject.SetActive(true);
    }

    //퇴장
    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    //갱신
    public virtual void UpdateUI()
    {
        
    }
    
    //애니메이션 시작
    protected void StartAnimation(int animationHash)
    {
        _uiManager.Animator.SetBool(animationHash, true);
    }

    //애니메이션 종료
    protected void StopAnimation(int animationHash)
    {
        _uiManager.Animator.SetBool(animationHash, false);
    }
}
