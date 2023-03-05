using System;
using System.Collections.Generic;
using UnityEngine;
using SaveAndLoadModule;
using UnityEngine.Rendering.VirtualTexturing;

public class InventoryController : BasePlayerContoller
{
    [SerializeField] private UIContainer _uiContainer = null;

    [SerializeField] private int _inventoryCapacity = 42;
    [SerializeField] private int _equipmentCapacity = 12;

    public event Action<int> OnMoneyChanged;
    public static InventoryController Instance => _instance;

    public InventoryWithSlots Inventory
    {
        get
        {
            if (_inventory == null)
                _inventory = new InventoryWithSlots(_inventoryCapacity);
            return _inventory;
        }
    }
    public InventoryWithSlots Equipment
    {
        get
        {
            if (_equipment == null)
                _equipment = new InventoryWithSlots(_equipmentCapacity);
            return _equipment;
        }
    }
    public UIQuickAccessMenu QuickAccessMenu => _quickAccessMenu;
    public int Money => _money;

    private static InventoryController _instance;

    private ISaveLoadSystem _saveLoadSystem = null;

    private QuestSubSystem _questSubSystem = null;

    private InventoryWithSlots _equipment;
    private InventoryWithSlots _inventory;

    private UIQuickAccessMenu _quickAccessMenu;
    private UIQuickAccessMenu _quickAccessMenuhud;
    private UIInventoryController _uiInventoryController;

    private int _money;

    private void Awake()
    {
        _instance = this;

        _quickAccessMenu = _uiContainer.QuickAccessMenu;
        _quickAccessMenuhud = _uiContainer.QuickAccessMenuhud;
        _uiInventoryController = _uiContainer.UIInventoryController;

        _uiInventoryController.UIInventory.Initialize(Inventory);
        _uiInventoryController.UIEquipment.Initialize(Equipment);

        _quickAccessMenu.Initialize(this);
        _quickAccessMenuhud.Initialize(this);

        _money = 0;
    }

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        _questSubSystem = ProjectSystem.GetSubSystem<QuestSubSystem>();
        _saveLoadSystem = ProjectSystem.GetSubSystem<ISaveLoadSystem>();
    }

    public override void Prepare()
    {
        _questSubSystem.OnQuestCompleted += ReceiveQuestReward;

        OnMoneyChanged?.Invoke(_money);
    }

    public override void Enable()
    {
        _questSubSystem.OnQuestCompleted += ReceiveQuestReward;
    }
    public override void Disable()
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
        OnMoneyChanged?.Invoke(_money);
        return true;
    }
    private void AddItemsFromReward(IQuestNote quest)
    {
        ItemsFactory factory = new ItemsFactory();

        foreach (var itemData in quest.Reward.Items)
        {
            IInventoryItem item = factory.SpawnItem(itemData.Info);
            item.State.amount = itemData.Amount;

            Inventory.TryToAdd(this, item);
        }
    }

    public void Save()
    {
        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, _quickAccessMenu.Slots.Length);

        //[TODO] Переработать...
        //_gameData = GameDataContainer.Instance;

        //SaveInventory(_gameData);
        //SaveEquipment(_gameData);
        //SaveQAM(_gameData);

        //Storage storage = new Storage();
        //storage.Save(_gameData);
        //..

        //Предположительное решение:
        SaveInventory(playerInventoryData);
        SaveEquipment(playerInventoryData);
        SaveQAM(playerInventoryData);

        _saveLoadSystem.Save(playerInventoryData);
    }

    public void SaveInventory(PlayerInventoryData data)
    {
        Inventory.SaveData(data.PlayerInventory);
    }
    private void SaveEquipment(PlayerInventoryData data)
    {
        Inventory.SaveData(data.PlayerEquipment);
    }
    private void SaveQAM(PlayerInventoryData data)
    {
        for (int i = 0; i < _quickAccessMenu.Slots.Length; i++)
        {
            data.QuickAccessMenuItems.Items[i] = _quickAccessMenu.Slots[i].QuickAccessMenuItem.Item;
        }
    }

    public void Load()
    {
        //[TODO] Переработать...
        //Storage storage = new Storage();

        //_gameData = (GameDataContainer)storage.Load(GameDataContainer.Instance);

        //SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerInventory);
        //SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.PlayerEquipment);
        //SetItemsInfo(infoObjects, _gameData.PlayerInventoryData.QuickAccessMenuItems);

        //LoadInventory(_gameData);
        //LoadEquipment(_gameData);
        //LoadQAM(_gameData);
        //..

        //Предположительное решение:
        var playerInventoryData = _saveLoadSystem.Load<PlayerInventoryData>();

        InventoryItemInfo[] infoObjects = Resources.LoadAll<InventoryItemInfo>("Info");

        SetItemsInfo(infoObjects, playerInventoryData.PlayerInventory);
        SetItemsInfo(infoObjects, playerInventoryData.PlayerEquipment);
        SetItemsInfo(infoObjects, playerInventoryData.QuickAccessMenuItems);

        LoadInventory(playerInventoryData);
        LoadEquipment(playerInventoryData);
        LoadQAM(playerInventoryData);
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
    private void LoadInventory(PlayerInventoryData data)
    {
        Inventory.LoadData(data.PlayerInventory);
    }
    private void LoadEquipment(PlayerInventoryData data)
    {
        Inventory.LoadData(data.PlayerEquipment);
    }
    private void LoadQAM(PlayerInventoryData data)
    {
        for (int i = 0; i < _quickAccessMenu.Slots.Length; i++)
        {
            _quickAccessMenu.Slots[i].QuickAccessMenuItem.SetNewItem(data.QuickAccessMenuItems.Items[i]);
        }
    }
}
