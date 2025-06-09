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
    
    private BaseUI _currentState;
    
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
    }
    
    private const string EXITANIM = "IsExit";
    public string ExitAnim {get => EXITANIM; }
    
    private void Start()
    {
        MainMenuUI = GetComponentInChildren<MainMenuUI>(true);
        MainMenuUI.Init(this);
        StatusUI = GetComponentInChildren<StatusUI>(true);
        StatusUI.Init(this);
        InventoryUI = GetComponentInChildren<InventoryUI>(true);
        InventoryUI.Init(this);

        _currentState = MainMenuUI;
        ChangeState(MainMenuUI);
    }

    public void ChangeState(BaseUI state)
    {

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void UpdateUI()
    {
        _currentState.UpdateUI();
    }


}
