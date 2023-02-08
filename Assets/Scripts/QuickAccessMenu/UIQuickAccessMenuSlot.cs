using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIQuickAccessMenuSlot : MonoBehaviour, IDropHandler, IBindableSlot
{
    [SerializeField] private UIQuickAccessMenuItem _quickAccessMenuItem;
    
    public event Action OnSetNewItem;

    public UIQuickAccessMenuItem QuickAccessMenuItem => _quickAccessMenuItem;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();

        if (otherItemUI.Item is IUsableItem item)
        {
            _quickAccessMenuItem.SetNewItem(item);
            OnSetNewItem?.Invoke();
        }
        else
        {
            Debug.Log("Неверный тип предмета");
            return;
        }    
    }

    public void SetItem(IInventoryItem item)
    {
        _quickAccessMenuItem.SetNewItem(item);
    }

    public void OnBindingUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_quickAccessMenuItem.Amount == 0 || _quickAccessMenuItem.Item == null)
                return;

            IUsableItem item = (IUsableItem) InventoryController.Instance.Inventory.GetItemByTypeID(_quickAccessMenuItem.Item.TypeID);

            item.Use();
        }
    }
}
