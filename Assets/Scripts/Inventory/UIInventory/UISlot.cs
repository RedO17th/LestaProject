using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private UIInventoryItem _uiInventoryItem; 

    public IInventorySlot slot { get; private set; }

    private UIInventory _uiInventory;
    public UIInventory UIInventory => _uiInventory;

    private void Awake()
    {
        //Initialize()
    }

    public void Initialize(UIInventory uIInventory)
    {
        _uiInventory = uIInventory;
    }

    public void SetSlot(IInventorySlot newSlot)
    {
        slot = newSlot;
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UISlot>();
        var otherSlot = otherSlotUI.slot;
        var inventory = UIInventory.Inventory;

        IInventorySlot toSlot = slot;

        if ((otherItemUI.Item is IEquipment droppedItem) && droppedItem.State.isEquipped)
        {
            if (!slot.IsEmpty)
            {
                if ((slot.Item is IEquipment itemInSlot) && itemInSlot.EquipmentType == droppedItem.EquipmentType)
                {
                    itemInSlot.Equip();
                }
                else
                {
                    var emptySlot = UIInventory.Inventory.FindEmptySlot();
                    toSlot = emptySlot;

                    if (emptySlot == null)
                        return;
                }
            }
            droppedItem.UnEquip();
        }

        inventory.TransitFromSlotToSlot(this, otherSlot, toSlot, otherSlotUI.UIInventory);

        Refresh();
        otherSlotUI.Refresh();
    }

    public virtual void Refresh()
    {
        if (slot != null)
            _uiInventoryItem.Refresh(slot);
    }
}
