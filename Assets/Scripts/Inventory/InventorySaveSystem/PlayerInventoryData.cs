using SaveAndLoadModule;

[System.Serializable]
public class PlayerInventoryData : BaseData
{
    public InventoryData PlayerInventory;
    public InventoryData PlayerEquipment;
    public InventoryData QuickAccessMenuItems;

    public PlayerInventoryData(int inventoryCapacity, int equipmentCapacity, int quickAccessMenuItemsCapacity)
    {
        PlayerInventory = new InventoryData(inventoryCapacity);
        PlayerEquipment = new InventoryData(equipmentCapacity);
        QuickAccessMenuItems = new InventoryData(quickAccessMenuItemsCapacity);
    }
}

