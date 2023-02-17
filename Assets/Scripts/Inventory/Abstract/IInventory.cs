using System;

public interface IInventory 
{
    int Capacity { get; }
    bool IsFull { get; }

    IInventoryItem GetItemByType(Type itemType);
    IInventoryItem GetItemByTypeID(string itemTypeID);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItemsByType(Type itemType);
    IInventoryItem[] GetAllItemsByTypeID(string itemTypeID);
    IInventoryItem[] GetEquippedItems();

    int GetItemAmountByType(Type itemType);
    int GetItemAmountByTypeID(string itemTypeID);

    IInventorySlot FindEmptySlot();

    bool TryToAdd(object sender, IInventoryItem item);

    void RemoveByType(object sender, Type itemType, int amount = 1);

    void RemoveByTypeID(object sender, string itemTypeID, int amount = 1);

    bool HasItemByType(Type itemType, out IInventoryItem item);

    bool HasItemByTypeID(string itemTypeID, out IInventoryItem item);
}
