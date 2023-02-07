
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UIInventory _equipmentUI;

    [SerializeField] private UIInventory _inventoryUI;

    [SerializeField] private UIQuickAccessMenuSlot[] _quickAccessMenuSlots;

    public static PlayerInventory Instance => _instance;

    public InventoryWithSlots Inventory => _inventoryUI.Inventory;
    public InventoryWithSlots Equipment => _equipmentUI.Inventory;
    public UIQuickAccessMenuSlot[] QuickAccessMenuSlots => _quickAccessMenuSlots;

    private static PlayerInventory _instance;
    private GameData _gameData;

    private void Awake()
    {
        _instance = this;
    }


    public void SaveInventory(GameData gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerInventory);
    }

    public void LoadInventory(GameData gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerInventory);
    }

    public void SaveEquipment(GameData gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    public void LoadEquipment(GameData gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    public void SaveQAM(GameData gameData)
    {
        for (int i = 0; i < QuickAccessMenuSlots.Length; i++)
        {
            gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i] = QuickAccessMenuSlots[i].QuickAccessMenuItem.Item;
        }
    }

    public void LoadQAM(GameData gameData)
    {
        for (int i = 0; i < QuickAccessMenuSlots.Length; i++)
        {
            QuickAccessMenuSlots[i].QuickAccessMenuItem.SetNewItem(gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i]);
        }
    }

    public void Save()
    {
        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, QuickAccessMenuSlots.Length);

        _gameData = GameData.Instance;

        SaveInventory(_gameData);
        SaveEquipment(_gameData);
        SaveQAM(_gameData);
       
        Storage storage = new Storage();
        storage.Save(_gameData);
    }

    public void Load()
    {
        Storage storage = new Storage();

        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, QuickAccessMenuSlots.Length);

        _gameData = (GameData)storage.Load(GameData.Instance);

        InventoryItemInfo[] infoObjects = Resources.LoadAll<InventoryItemInfo>("Info");

        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerInventory);
        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerEquipment);
        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.QuickAccessMenuItems);

        LoadInventory(_gameData);
        LoadEquipment(_gameData);
        LoadQAM(_gameData);
    }

    private void SetItemsInfo(InventoryItemInfo[] infoObjects, InventoryData data)
    {
        for (int i = 0; i < data.Items.Length; i++)
        {
            foreach (var info in infoObjects)
            {
                if (info.TypeId == data.Items[i]?.TypeID)
                {
                    data.Items[i].SetInfo(info);
                    break;
                }
            }
        }
    }
}
