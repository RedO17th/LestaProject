using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWithSlots : IInventory
{

    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent; //кто добавил предмет в инвентарь, какой предмет и в каком количестве 
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;
    public event Action<object> OnInventoryStateChangedEvent;

    public int Capacity { get; protected set; } = 0;

    public bool IsFull => _slots.TrueForAll(slot => slot.IsFull);

    public List<IInventorySlot> Slots => _slots;

    private List<IInventorySlot> _slots;

    public InventoryWithSlots(int capacity)
    {
        Capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);

        for (int i = 0; i < capacity; i++)
            _slots.Add(new InventorySlot());
    }
    public void SendInventoryStateChangedEvent(object sender)
    {
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public IInventoryItem GetItemByType(Type itemType)
    {
        var slotWithItem = _slots.Find(slot => slot.ItemType == itemType);
        return slotWithItem?.Item;
    }

    public IInventoryItem GetItemByTypeID(string itemTypeID)
    {
        var slotWithItem = _slots.Find(slot => slot.Item?.TypeID == itemTypeID);
        return slotWithItem?.Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();

        foreach(var slot in _slots)
        {
            if (!slot.IsEmpty)
                allItems.Add(slot.Item);
        }

        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItemsByType(Type itemType)
    {
        var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);

        var allItemsOfType = new List<IInventoryItem>();
        
        foreach (var slot in slotsOfType)
            allItemsOfType.Add(slot.Item);

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetAllItemsByTypeID(string itemTypeID)
    {
        var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.Item.TypeID == itemTypeID);

        var allItemsOfType = new List<IInventoryItem>();

        foreach (var slot in slotsOfType)
            allItemsOfType.Add(slot.Item);

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var allEquippedItems= new List<IInventoryItem>();

        var requiredSlots = _slots.
            FindAll(slot => !slot.IsEmpty && slot.Item.State.isEquipped);

        foreach (var slot in requiredSlots)
            allEquippedItems.Add(slot.Item);

        return allEquippedItems.ToArray();
    }

    public int GetItemAmountByType(Type itemType)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);

        foreach (var slot in allItemSlots)
            amount += slot.Amount;

        return amount; 
    }

    public int GetItemAmountByTypeID(string itemTypeID)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.Item.TypeID == itemTypeID);

        foreach (var slot in allItemSlots)
            amount += slot.Amount;

        return amount;
    }

    public IInventorySlot FindEmptySlot()
    {
        return _slots.Find(slot => slot.IsEmpty);
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotFull = _slots.Find(slot => !slot.IsEmpty
                                                             && !slot.IsFull
                                                             && slot.Item.TypeID == item.TypeID);

        if (slotWithSameItemButNotFull != null)
            return TryToAddToSlot(sender, slotWithSameItemButNotFull, item);

        var emptySlot = FindEmptySlot();

        if (emptySlot != null)
            return TryToAddToSlot(sender, emptySlot, item);

        Debug.Log("Cannot add item");
        return false;
    }

    public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.Amount + item.State.amount <= item.ItemInfo.MaxItemsInInventorySlot;

        var amountToAdd = fits ? item.State.amount : item.ItemInfo.MaxItemsInInventorySlot - slot.Amount;

        var amountLeft = item.State.amount - amountToAdd;

        if (slot.IsEmpty)
        {
            var clonedItem = item.Clone();

            clonedItem.State.amount = amountToAdd;

            slot.SetItem(clonedItem);
        }
        else
            slot.Item.State.amount += amountToAdd;

        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangedEvent?.Invoke(sender);

        if (amountLeft <= 0)
            return true;

        item.State.amount = amountLeft;
        return TryToAdd(sender, item);
    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot, UIInventory fromInventory)
    {
        bool sameInventory = this == fromInventory.Inventory;

        if (sameInventory)
            TransitInsideInventory(sender, fromSlot, toSlot);
        else
            TransitBetweenInventories(sender, fromSlot, toSlot, fromInventory);
    }

    public void TransitInsideInventory(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.IsEmpty)
            return;

        if (fromSlot == toSlot)
            return;

        if (!toSlot.IsEmpty && (fromSlot.Item.TypeID != toSlot.Item.TypeID|| toSlot.Item.ItemInfo.MaxItemsInInventorySlot == 1))
        {
            ChangeItemsInSlots(sender, fromSlot, toSlot);
            return;
        }

        if (toSlot.IsFull)
            return;

        int slotCapacity = fromSlot.Capacity;
        bool fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
        int amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
        int amountLeft = fromSlot.Amount - amountToAdd;

        if (toSlot.IsEmpty)
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
            SendInventoryStateChangedEvent(sender);
            return;
        }

        toSlot.Item.State.amount += amountToAdd;

        if (fits)
            fromSlot.Clear();
        else
            fromSlot.Item.State.amount = amountLeft;

        SendInventoryStateChangedEvent(sender);
    }

    public void TransitBetweenInventories(object sender, IInventorySlot fromSlot, IInventorySlot toSlot, UIInventory fromInventory)
    {
        if (fromSlot.IsEmpty)
            return;

        if (!toSlot.IsEmpty && (fromSlot.Item.TypeID != toSlot.Item.TypeID || toSlot.Item.ItemInfo.MaxItemsInInventorySlot == 1))
        {
            ChangeItemsInSlots(sender, fromSlot, toSlot, fromInventory);
            return;
        }

        if (toSlot.IsFull)
            return;

        int slotCapacity = fromSlot.Capacity;
        bool fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
        int amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
        int amountLeft = fromSlot.Amount - amountToAdd;

        if (toSlot.IsEmpty)
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
            SendInventoryStateChangedEvent(sender);
            fromInventory.Inventory.SendInventoryStateChangedEvent(sender);
            return;
        }

        toSlot.Item.State.amount += amountToAdd;

        if (fits)
            fromSlot.Clear();
        else
        {
            fromSlot.Item.State.amount = amountLeft;
  
            fits = TryToAdd(sender, fromSlot.Item);
            if (fits)
                fromInventory.Inventory.RemoveFromSlot(sender, fromSlot, fromSlot.Item.State.amount);
            else
                fromInventory.Inventory.RemoveFromSlot(sender, fromSlot, amountLeft - fromSlot.Item.State.amount);
        }

        SendInventoryStateChangedEvent(sender);
        fromInventory.Inventory.SendInventoryStateChangedEvent(sender);
    }

    private void ChangeItemsInSlots(object sender, IInventorySlot fromSlot, IInventorySlot toSlot, UIInventory fromInventory = null)
    {
        IInventoryItem savedItem = toSlot.Item;

        toSlot.SetItem(fromSlot.Item);

        fromSlot.SetItem(savedItem);

        OnInventoryStateChangedEvent?.Invoke(sender);

        if (fromInventory != null)
            fromInventory.Inventory.SendInventoryStateChangedEvent(sender);
    }

    public void RemoveByType(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlotsWithItemType(itemType);
        RemoveFromSlots(sender, slotsWithItem, amount);
    }

    public void RemoveByTypeID(object sender, string itemTypeID, int amount = 1)
    {
        var slotsWithItem = GetAllSlotsWithItemTypeId(itemTypeID);
        RemoveFromSlots(sender, slotsWithItem, amount);
    }

    public void RemoveFromSlots(object sender, IInventorySlot[] slotsWithItem, int amount)
    {
        if (slotsWithItem.Length == 0)
            return;

        var amountToRemove = amount;
        var count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.Amount >= amountToRemove)
            {
                slot.Item.State.amount -= amountToRemove;

                if (slot.Amount == 0)
                    slot.Clear();

                OnInventoryItemRemovedEvent?.Invoke(sender, slot.Item.Type, amountToRemove);
                OnInventoryStateChangedEvent?.Invoke(sender);

                break;
            }

            var amountRemoved = slot.Amount;
            amountToRemove -= slot.Amount;
            slot.Clear();

            OnInventoryItemRemovedEvent?.Invoke(sender, slot.Item.Type, amountRemoved);
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
    }

    public void RemoveFromSlot(object sender, IInventorySlot slot, int amount = 1)
    {
        if (slot.IsEmpty)
            return;

        if (slot.Item.State.amount < amount)
            return;

        slot.Item.State.amount -= amount;

        if (slot.Item.State.amount == 0)
            slot.Clear();

        OnInventoryItemRemovedEvent?.Invoke(sender, slot.ItemType, amount);
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public IInventorySlot[] GetAllSlotsWithItemType(Type itemType)
    {
        return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
    }

    public IInventorySlot[] GetAllSlotsWithItemTypeId(string itemTypeId)
    {
        return _slots.FindAll(slot => !slot.IsEmpty && slot.Item.TypeID == itemTypeId).ToArray();
    }


    public bool HasItemByType(Type itemType, out IInventoryItem item)
    {
        item = GetItemByType(itemType);
        return item != null;
    }

    public bool HasItemByTypeID(string itemTypeID, out IInventoryItem item)
    {
        item = GetItemByTypeID(itemTypeID);
        return item != null;
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();   
    }

    public void SaveData(InventoryData data)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (_slots[i].Item != null)
            {
                data.Items[i] = _slots[i].Item;
            }
        }
    }

    public void LoadData(InventoryData data)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (data.Items[i] != null)
                _slots[i].SetItem(data.Items[i]);
            else
                _slots[i].Clear();
        }
        SendInventoryStateChangedEvent(this);
    }
}
