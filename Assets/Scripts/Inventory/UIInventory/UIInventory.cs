using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private int _inventoryCapacity = 25;
    [SerializeField] private UISlot[] _uiSlots;

    private InventoryWithSlots _inventory = null; 

    public InventoryWithSlots Inventory 
    { 
        get 
        { 
            if (_inventory == null) 
                _inventory = new InventoryWithSlots(_inventoryCapacity);
            return _inventory;
        }
    }

    private void Awake()
    {
        //Initialize();
    }

    public void Initialize()
    {
        Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        foreach(var slot in _uiSlots)
        {
            slot.Initialize();
        }

        SetupInventoryUI(Inventory);
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;

        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }

    private void OnInventoryStateChanged(object sender)
    {
        foreach (var slot in _uiSlots)
            slot.Refresh();
    }

    public void OnOpenOrClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        //Кинуть ивент, что инвентарь закрылся или открылся 
    }
}
