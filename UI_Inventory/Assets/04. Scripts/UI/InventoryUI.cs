using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI inventorySize;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject slots;
    [SerializeField] private GameObject slot;

    [SerializeField] private int slotCount = 9;
    [SerializeField] private float slotInterval = 5f;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        inventorySize.text = $"0 / {slotCount}";
        SetSlot();
        
        backButton.onClick.AddListener(OnClickBackButton);
    }

    protected override UIState GetState()
    {
        return UIState.Inventory;
    }

    
    //개선 여지 다수
    private void SetSlot()
    {
        RectTransform size = slot.GetComponent<RectTransform>();
        float width = size.rect.width;
        float height = size.rect.height;
        
        for (int i = 0; i < slotCount; i++)
        {
            GameObject go = Instantiate(slot,slots.transform);
            float x = (width + slotInterval) * (i % 3);
            float y = -((height + slotInterval) * (i / 3));
            
            go.transform.localPosition = new Vector2(x, y);
        }
    }

    private void OnClickBackButton()
    {
        _uiManager.ChangeState(UIState.MainMenu);
    }

    private void OnDisable()
    {
        foreach (Transform slot in slots.transform)
        {
            Destroy(slot.gameObject);
        }
    }
}
