public interface IItemsFactory
{
    IInventoryItem SpawnItem(IInventoryItemInfo info);
  
}

public class ItemsFactory : IItemsFactory
{
    public IInventoryItem SpawnItem(IInventoryItemInfo info)
    {
        if(info is EquipmentInfo equipmentInfo)
        {
            return new Equipment(equipmentInfo);
        }
        else if (info is UsableItemInfo usableItemInfo)
        {
            return new UsableItem(usableItemInfo);
        }
        else if(info is WeaponInfo weaponInfo)
        {
            return new Weapon(weaponInfo);
        }
        return new InventoryItem(info);
    }
}
