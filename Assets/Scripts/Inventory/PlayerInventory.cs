using UnityEngine;
using SaveAndLoadModule;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UIInventory _equipmentUI;

    [SerializeField] private UIInventory _inventoryUI;

    [SerializeField] private UIQuickAccessMenuSlot[] _quickAccessMenuSlots;

    public InventoryWithSlots Inventory => _inventoryUI.Inventory;
    public InventoryWithSlots Equipment => _equipmentUI.Inventory;
    public UIQuickAccessMenuSlot[] QuickAccessMenuSlots => _quickAccessMenuSlots;

    private int _money;
    private GameDataContainer _gameData;
    private QuestSubSystem _questSubSystem = null;

    //New SaveLoad logic - USE
    private SaveAndLoadSubSystem _saveLoadSystem = null;
    //

    private void Start()
    {
        _questSubSystem = ProjectSystem.GetSubSystem<QuestSubSystem>();
        _saveLoadSystem = ProjectSystem.GetSubSystem<SaveAndLoadSubSystem>();

        _questSubSystem.OnQuestCompleted += ReceiveQuestReward;
    }
    private void OnDisable()
    {
        _questSubSystem.OnQuestCompleted -= ReceiveQuestReward;
    }

    private void ReceiveQuestReward(object sender, IQuestNote quest)
    {
        TryChangeMoney(quest.Reward.Money);

        AddItemsFromReward(quest);
    }

    private bool TryChangeMoney(int value)
    {
        if (_money + value < 0)
            return false;

        _money += value;
        return true;
    }

    private void AddItemsFromReward(IQuestNote quest)
    {
        ItemsFactory factory = new ItemsFactory();

        foreach (var itemData in quest.Reward.Items)
        {
            IInventoryItem item = factory.SpawnItem(itemData.Info);
            item.State.amount = itemData.Amount;

            _inventoryUI.Inventory.TryToAdd(this, item);
        }
    }

    public void Save()
    {
        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, QuickAccessMenuSlots.Length);

        _gameData = GameDataContainer.Instance;

        SaveInventory(_gameData);
        SaveEquipment(_gameData);
        SaveQAM(_gameData);

        //Storage storage = new Storage();
        //storage.Save(_gameData);

        var journalData = GameDataContainer.Instance.PlayerJournalData;
        _saveLoadSystem.Save(journalData);
    }

    private void SaveInventory(GameDataContainer gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerInventory);
    }

    private void SaveEquipment(GameDataContainer gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    private void SaveQAM(GameDataContainer gameData)
    {
        for (int i = 0; i < QuickAccessMenuSlots.Length; i++)
        {
            gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i] = QuickAccessMenuSlots[i].QuickAccessMenuItem.Item;
        }
    }

    public void Load()
    {
        Storage storage = new Storage();

        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, QuickAccessMenuSlots.Length);

        _gameData = storage.Load(GameDataContainer.Instance) as GameDataContainer;

        InventoryItemInfo[] infoObjects = Resources.LoadAll<InventoryItemInfo>("Info");

        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerInventory);
        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerEquipment);
        SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.QuickAccessMenuItems);

        LoadInventory(_gameData);
        LoadEquipment(_gameData);
        LoadQAM(_gameData);
    }

    private void LoadInventory(GameDataContainer gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerInventory);
    }

    private void LoadEquipment(GameDataContainer gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    private void LoadQAM(GameDataContainer gameData)
    {
        for (int i = 0; i < QuickAccessMenuSlots.Length; i++)
        {
            QuickAccessMenuSlots[i].QuickAccessMenuItem.SetNewItem(gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i]);
        }
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
