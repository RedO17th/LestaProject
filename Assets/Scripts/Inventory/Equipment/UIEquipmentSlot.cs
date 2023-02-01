using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEquipmentSlot : UISlot
{
    [SerializeField] private EquipmentType _expectedEquipmentType;

    public override void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UISlot>();

        bool sameInventory = otherSlotUI.UIInventory.Inventory == UIInventory.Inventory;

        IEquipment newItem = null;
        IEquipment oldItem = (IEquipment)slot?.Item;

        if (otherItemUI.Item is IEquipment item)
        {
            newItem = item; 
        }
        else
        {
            Debug.Log("Неверный тип предмета");
            return;
        }

        if (newItem.EquipmentType != _expectedEquipmentType)
        {
            Debug.Log("Неверный тип предмета");
            return;
        }

        
        var otherSlot = otherSlotUI.slot;
        var inventory = UIInventory.Inventory;

        inventory.TransitFromSlotToSlot(this, otherSlot, slot, otherSlotUI.UIInventory);

        Refresh();
        otherSlotUI.Refresh();

        if (sameInventory)
            return;

        if(oldItem != null)
            oldItem.UnEquip();

        newItem.Equip();
    }
}
