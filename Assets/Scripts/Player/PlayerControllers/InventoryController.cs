using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : BasePlayerContoller
{
    [SerializeField] private UIQuickAccessMenu _quickAccessMenu;

    [SerializeField] private UIQuickAccessMenu _quickAccessMenuhud;

    [SerializeField] private UIInventoryController _uiInventoryController;

    [Space]
    [SerializeField] private int _inventoryCapacity = 42;
    [SerializeField] private int _equipmentCapacity = 12;


    public static InventoryController Instance => _instance;

    public event Action<int> OnMoneyChanged;

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

    private int _money;

    private GameDataContainer _gameData;

    private QuestSubSystem _questSubSystem = null;

    private InventoryWithSlots _equipment;
    private InventoryWithSlots _inventory;

    private void Awake()
    {
        _instance = this;
        Initialize();
    }

    public void Initialize()
    {
        //_equipment.Initialize();
        //_inventory.Initialize();
        _uiInventoryController.UIInventory.Initialize(Inventory);
        _uiInventoryController.UIEquipment.Initialize(Equipment);


        _quickAccessMenu.Initialize(this);
        _quickAccessMenuhud.Initialize(this);


    }
    private void Start()
    {
        _questSubSystem = ProjectSystem.GetSubSystem<QuestSubSystem>();

        _questSubSystem.OnQuestCompleted += ReceiveQuestReward;

        _money = 0;
        
        OnMoneyChanged?.Invoke(_money);
    }
    private void OnDisable()
    {
        //_questSubSystem.OnQuestCompleted -= ReceiveQuestReward;
    }

    private void ReceiveQuestReward(object sender, IQuestNote quest)
    {
        TryChangeMoney(quest.Reward.Money);

        AddItemsFromReward(quest);
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

    public bool TryChangeMoney(int value)
    {
        if (_money + value < 0)
            return false;

        _money += value;
        OnMoneyChanged?.Invoke(_money);
        return true;
    }

    public void SaveInventory(GameDataContainer gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerInventory);
    }

    public void LoadInventory(GameDataContainer gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerInventory);
    }

    public void SaveEquipment(GameDataContainer gameData)
    {
        Inventory.SaveData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    public void LoadEquipment(GameDataContainer gameData)
    {
        Inventory.LoadData(gameData.PlayerInventoryData.PlayerEquipment);
    }

    public void SaveQAM(GameDataContainer gameData)
    {
        for (int i = 0; i < _quickAccessMenu.Slots.Length; i++)
        {
            gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i] = _quickAccessMenu.Slots[i].QuickAccessMenuItem.Item;
        }
    }

    public void LoadQAM(GameDataContainer gameData)
    {
        for (int i = 0; i < _quickAccessMenu.Slots.Length; i++)
        {
            _quickAccessMenu.Slots[i].QuickAccessMenuItem.SetNewItem(gameData.PlayerInventoryData.QuickAccessMenuItems.Items[i]);
        }
    }

    public void Save()
    {
        PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, _quickAccessMenu.Slots.Length);

        _gameData = GameDataContainer.Instance;

        SaveInventory(_gameData);
        SaveEquipment(_gameData);
        SaveQAM(_gameData);

        Storage storage = new Storage();
        storage.Save(_gameData);
    }

    public void Load()
    {
        Storage storage = new Storage();

        //PlayerInventoryData playerInventoryData = new PlayerInventoryData(Inventory.Capacity, Equipment.Capacity, _quickAccessMenu.Slots.Length);

        _gameData = (GameDataContainer)storage.Load(GameDataContainer.Instance);

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
