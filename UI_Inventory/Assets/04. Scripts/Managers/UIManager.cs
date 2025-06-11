using System.Threading.Tasks;
using UnityEngine;
    
//<Summary>
//UI를 관리하는 클래스 역할과 스테이트 머신 역할
//</Summary>
public class UIManager : MonoBehaviour
{
    //싱글톤 할당
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
    
    //필드
    private BaseUI _currentState;
    
    //직렬화 데이터
    [field: SerializeField] public UIAnimationData AnimationData { get; private set; }
    
    //프로퍼티
    public Animator Animator { get; private set; }
    //UI의 상태
    public MainMenuUI MainMenuUI { get; private set; }
    public StatusUI StatusUI{ get; private set; }
    public InventoryUI InventoryUI{ get; private set; }
    
    private void Awake()
    {
        //싱글톤 할당
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        
        //애니메이션 데이터 생성
        AnimationData = new UIAnimationData();
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        //상태 생성
        MainMenuUI = GetComponentInChildren<MainMenuUI>(true);
        MainMenuUI.Init(this);
        StatusUI = GetComponentInChildren<StatusUI>(true);
        StatusUI.Init(this);
        InventoryUI = GetComponentInChildren<InventoryUI>(true);
        InventoryUI.Init(this);
        
        //시작 상태
        _currentState = MainMenuUI;
        _currentState.Enter();
    }


    //상태 변경
    public async void ChangeState(BaseUI newState)
    {
        _currentState?.Exit();
        
        //애니메이션 연출을 위해서 잠시 딜레이
        var animLength = Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        _currentState = newState;
        _currentState.Enter();
    }

    //UI 업데이트
    public void UpdateUI()
    {
        _currentState.UpdateUI();
    }


}
