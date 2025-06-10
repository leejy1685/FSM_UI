using System.Threading.Tasks;
using UnityEngine;
    
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
    
    [field: SerializeField] public UIAnimationData AnimationData { get; private set; }
    
    private BaseUI _currentState;
    
    public Animator Animator { get; private set; }
    public MainMenuUI MainMenuUI { get; private set; }
    public StatusUI StatusUI{ get; private set; }
    public InventoryUI InventoryUI{ get; private set; }
    
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
        
        AnimationData = new UIAnimationData();
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
        Animator.speed = 1f;
    }
    
    private void Start()
    {
        MainMenuUI = GetComponentInChildren<MainMenuUI>(true);
        MainMenuUI.Init(this);
        StatusUI = GetComponentInChildren<StatusUI>(true);
        StatusUI.Init(this);
        InventoryUI = GetComponentInChildren<InventoryUI>(true);
        InventoryUI.Init(this);
        
        _currentState = MainMenuUI;
        _currentState.Enter();
    }


    public async void ChangeState(BaseUI newState)
    {
        _currentState?.Exit();
        
        var animLength = Animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.RoundToInt(animLength * 1000));
        
        _currentState = newState;
        _currentState.Enter();
    }

    public void UpdateUI()
    {
        _currentState.UpdateUI();
    }


}
