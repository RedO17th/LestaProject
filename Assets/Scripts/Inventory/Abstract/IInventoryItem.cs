using System;

public interface IInventoryItem
{
    IInventoryItemInfo ItemInfo { get; }
    IInventoryItemState State { get; }
    Type Type { get; }

    string TypeID { get; }

    IInventoryItem Clone();

    public void SetInfo(IInventoryItemInfo itemInfo);
}
