using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : UISlot
{
    [SerializeField] private Image _background;

    public override void OnDrop(PointerEventData eventData)
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

    public override void Refresh()
    {
        _background.enabled = !slot.IsEmpty;

        base.Refresh();
    }

}
