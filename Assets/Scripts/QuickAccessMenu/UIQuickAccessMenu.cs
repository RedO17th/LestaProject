using System;
using System.Collections.Generic;
using UnityEngine;

public class UIQuickAccessMenu : MonoBehaviour
{
    [SerializeField] private UIQuickAccessMenuSlot[] _slots;

    public static event Action OnSetNewItem;

    public UIQuickAccessMenuSlot[] Slots => _slots;

    private InventoryController _inventoryController;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].QuickAccessMenuItem.Initialize(inventoryController);
            //_slots[i].OnSetNewItem += OnSetNewItemHandler;
            inventoryController.QuickAccessMenu.Slots[i].OnSetNewItem += OnSetNewItemHandler;
        }

        OnSetNewItem += ResetItems;
        //_slots[i].SetItem(inventoryController.QuickAccessMenuSlots[i].QuickAccessMenuItem.Item);
    }

    public void ResetItems()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].QuickAccessMenuItem.SetNewItem(_inventoryController.QuickAccessMenu.Slots[i].QuickAccessMenuItem.Item);
        }
    }

    public void OnSetNewItemHandler()
    {
        OnSetNewItem?.Invoke();
    }
}
