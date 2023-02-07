using System;

public class InventorySlot : IInventorySlot
{
    public bool IsFull => !IsEmpty && Amount == Capacity;

    public bool IsEmpty => Item == null;

    public IInventoryItem Item { get; private set; }

    public Type ItemType => IsEmpty ? null : Item.Type;

    public int Amount => IsEmpty ? 0 : Item.State.amount;

    public int Capacity { get; private set; }

    public void SetItem(IInventoryItem item)
    {
        //if(!isEmpty)
        //    return;

        this.Item = item;
        this.Capacity = item.ItemInfo.MaxItemsInInventorySlot;
    }

    public void Clear()
    {
        if (IsEmpty)
            return;

        Item = null;
    }
}
