[System.Serializable]
public class InventoryData
{
    public IInventoryItem[] Items;

    public InventoryData(int capacity)
    {
       Items = new IInventoryItem[capacity];
    }
}

