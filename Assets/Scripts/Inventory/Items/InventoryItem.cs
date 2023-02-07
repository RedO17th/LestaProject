using System;

[Serializable]
public class InventoryItem : IInventoryItem
{
    [NonSerialized]
    protected IInventoryItemInfo _itemInfo;

    public IInventoryItemInfo ItemInfo => _itemInfo;

    public IInventoryItemState State { get; protected set; }

    public Type Type => GetType();

    public string TypeID { get; private set; }

    public InventoryItem(IInventoryItemInfo itemInfo)
    {
        _itemInfo = itemInfo;
        TypeID = _itemInfo.TypeId;
        State = new InventoryItemState();
    }

    public virtual IInventoryItem Clone()
    {
        var clonnedItem = new InventoryItem(ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }

    public void SetInfo(IInventoryItemInfo itemInfo)
    {
        _itemInfo = itemInfo;
    }
}
