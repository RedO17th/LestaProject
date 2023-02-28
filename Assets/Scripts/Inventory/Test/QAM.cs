using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class QAM : MonoBehaviour
{
    [SerializeField] private int _capacity;

    [SerializeField] private QAMUIController _qamUIController;

    public InventoryWithSlots Inventory;

    private QAMSlot[] _slots;

    public void Initialize()
    {
        //_items = new IInventoryItem[_capacity];
        _slots = new QAMSlot[_capacity];
        //Inventory = (ProjectSystem.GetSubSystem<PlayerSubSystem>().GetPlayerControllerBy(PlayerControllerType.Inventory) as InventoryController).Inventory;
        //_qamUIController.Initialize()
    }


}




public class QAMSlot
{
    private IInventoryItem _item;

    public int Amount => _qam.Inventory.GetItemAmountByTypeID(_item.TypeID);

    private QAM _qam;

    public void Initialize(QAM qam)
    {
        _qam = qam;
    }

    public void SetItem(IInventoryItem item)
    {
        _item = item;
    }

}


public class QAMUI
{
    [SerializeField] private UIQAMSlot[] _uiQAMSlosts;
}

public class QAMUIController
{
    public QAMUI QAMUI; 


}


public class UIQAMSlot : MonoBehaviour, IDropHandler, IBindableSlot
{
    [SerializeField] private UIQAMItem _uiQAMItem;

    public UIQAMItem UIQAMItem => _uiQAMItem;

    private QAMUI _qamUI;

    public QAMSlot QAMSlot { get; private set; }

    public void Initialize(QAMUI qamUI)
    {
        _qamUI = qamUI;
    }

    public void SetSlot(QAMSlot qamSlot)
    {
        QAMSlot = qamSlot;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();

        if (otherItemUI.Item is IUsableItem item)
        {
            //UIQAMItem.SetNewItem(item);
            //OnSetNewItem?.Invoke();
        }
        else
        {
            Debug.Log("Неверный тип предмета");
            return;
        }
    }

    public void Refresh()
    {

    }

    public void OnBindingUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //if (_quickAccessMenuItem.Amount == 0 || _quickAccessMenuItem.Item == null)
            //    return;

            //IUsableItem item = (IUsableItem)InventoryController.Instance.Inventory.GetItemByTypeID(_quickAccessMenuItem.Item.TypeID);

            //item.Use();
        }
    }

}

public class UIQAMItem : MonoBehaviour
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private TextMeshProUGUI _textAmount;

    public IInventoryItem Item { get; private set; }

    private Coroutine _showTooltipWithDelay;
    private RectTransform _rectTransform;

    public int Amount => Item != null ? Item.State.amount : 0;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Initialize(InventoryController inventoryController)
    {
        //InventoryController inventoryController = ProjectSystem.GetSubSystem<PlayerSubSystem>().GetPlayerControllerBy(PlayerControllerType.Inventory) as InventoryController;
        //inventoryController.Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        //Refresh();
    }

    private void OnInventoryStateChanged(object sender)
    {
        //Refresh();
    }

    public void Refresh()
    {
        if (Item == null)
        {
            Disable();
            return;
        }

        Enable();

        Item.State.amount = UpdateAmount();
        _textAmount.text = Item.State.amount.ToString();

        if (Amount == 0 && _textAmount.enabled)
        {
            _textAmount.enabled = false;
            _imageIcon.color = Color.gray;
        }
        if (Amount > 0 && !_textAmount.enabled)
        {
            _textAmount.enabled = true;
            _imageIcon.color = Color.white;
        }
    }
    private void Disable()
    {
        _imageIcon.gameObject.SetActive(false);
        _textAmount.gameObject.SetActive(false);
    }

    private void Enable()
    {
        _imageIcon.gameObject.SetActive(true);
        _textAmount.gameObject.SetActive(true);
    }

    public void SetNewItem(IInventoryItem item)
    {
        if (item == null)
            return;


        Item = item.Clone();
        _imageIcon.sprite = Item.ItemInfo.SpriteIcon;
        Refresh();
    }

    public int UpdateAmount()
    {
        return InventoryController.Instance.Inventory.GetItemAmountByTypeID(Item.TypeID);
    }
}