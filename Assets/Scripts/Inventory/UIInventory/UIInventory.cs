using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UISlot[] _uiSlots;

    private InventoryWithSlots _inventory;

    public InventoryWithSlots Inventory => _inventory;

    public void Initialize(InventoryWithSlots inventory)
    {
        _inventory = inventory;
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        foreach(var slot in _uiSlots)
        {
            slot.Initialize(this);
        }

        SetupInventoryUI(inventory);
    }

    public void SetupInventoryUI(InventoryWithSlots inventory)
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
}
