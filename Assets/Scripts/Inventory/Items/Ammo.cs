
public class Ammo : InventoryItem
{
    public Ammo(IInventoryItemInfo itemInfo):base(itemInfo)
    {

    }

    public override IInventoryItem Clone()
    {
        var clonnedItem = new Ammo(ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }
}
