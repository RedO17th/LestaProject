using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class Test : MonoBehaviour
{
    [SerializeField] private Text _amountText;
    [SerializeField] private TMP_Dropdown _dropdown;

    [Space]
    [SerializeField] private UsableItemInfo _appleInfo;
    [SerializeField] private UsableItemInfo _breadInfo;
    [SerializeField] private EquipmentInfo _glovesInfo;
    [SerializeField] private EquipmentInfo _helmetInfo;
    [SerializeField] private InventoryItemInfo _doorkeyInfo;
    [SerializeField] private InventoryItemInfo _goldenKeyInfo;
    [SerializeField] private EquipmentInfo _glovesInfo2;
    [SerializeField] private EquipmentInfo _helmetInfo2;
    [SerializeField] private WeaponInfo _makaroffInfo;
    [SerializeField] private InventoryItemInfo _bullets;

    private IInventoryItem _selectedItem;
    private int _selectedAmount;


    public void AddItemButton()
    {
        GetValuesFromUI();

        if (_selectedItem == null || _selectedAmount < 1)
            return;

        PlayerInventory.Instance.Inventory.TryToAdd(this, _selectedItem);
    }

    public void RemoveItemButton()
    {
        GetValuesFromUI();

        if (_selectedItem == null || _selectedAmount < 1)
            return;

        //PlayerInventory.Instance.inventory.Remove(this, _selectedItem.Type, _selectedAmount);
        PlayerInventory.Instance.Inventory.RemoveByTypeID(this, _selectedItem.ItemInfo.TypeId, _selectedAmount);
    }

    private void GetValuesFromUI()
    {
        SelectItem(_dropdown.value);

        
        _selectedAmount = int.Parse(_amountText.text);  //Convert.ToInt32(_amountText.text);

        _selectedItem.State.amount = _selectedAmount;
    }

    public void SelectItem(int value)
    {
        ItemsFactory factory = new ItemsFactory();
        if (value == 0)
        {
            _selectedItem = factory.SpawnItem(_appleInfo);
        }
        if (value == 1)
        {
            _selectedItem = factory.SpawnItem(_breadInfo);
        }
        if(value == 2)
        {
            _selectedItem = factory.SpawnItem(_glovesInfo);
        }
        if(value == 3)
        {
            _selectedItem = factory.SpawnItem(_helmetInfo);
        }
        if (value == 4)
        {
            _selectedItem = factory.SpawnItem(_doorkeyInfo);
        }
        if (value == 5)
        {
            _selectedItem = factory.SpawnItem(_goldenKeyInfo);
        }
        if (value == 6)
        {
            _selectedItem = factory.SpawnItem(_glovesInfo2);
        }
        if (value == 7)
        {
            _selectedItem = factory.SpawnItem(_helmetInfo2);
        }
        if (value == 8)
        {
            _selectedItem = factory.SpawnItem(_makaroffInfo);
        }
        if(value == 9)
        {
            _selectedItem = factory.SpawnItem(_bullets);
        }
    }

    public void SaveInventory(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        PlayerInventory.Instance.Save();
    }

    public void LoadInventory(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        PlayerInventory.Instance.Load();
    }

    public void UseGun(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        IInventoryItem[] equipment = PlayerInventory.Instance.Equipment.GetEquippedItems();

        foreach (var item in equipment)
        {
            if (item is IWeapon weapon)
            {
                Debug.Log("Экипированное оружие найдено");
                Attack(weapon);
                return;
            }
        }
        Debug.Log("Экипированное оружие не найдено");
    }

    private void Attack(IWeapon weapon)
    {
        if (!UseBullet(((WeaponInfo)weapon.ItemInfo).Bullets.TypeId))
        {
            Debug.Log("Нет пуль");
            return;
        }

        Debug.Log($"Используется оружие {weapon.ItemInfo.Title}\n");

        int attackRoll = DiceRoller.D20();
        int attack = attackRoll + weapon.AttackBonus;

        Debug.Log($"Атака = {attack} ({attackRoll} + {weapon.AttackBonus})\n");

        int difficult = 10;

        if (attack > difficult)
        {
            int damageRoll = DiceRoller.Roll(weapon.DamageDice, weapon.DamageDiceAmount);
            int damage = damageRoll + weapon.DamageBonus;
            Debug.Log($"Попадание, урон = {damage} ({damageRoll} ({weapon.DamageDiceAmount}{weapon.DamageDice}) + {weapon.DamageBonus})");
        }
        else
        {
            Debug.Log("Промах");
        }
    }
    private bool UseBullet(string BulletsTypeID)
    {
        int bulletAmountInInventory = PlayerInventory.Instance.Inventory.GetItemAmountByTypeID(BulletsTypeID);

        if(bulletAmountInInventory == 0)
            return false;

        PlayerInventory.Instance.Inventory.RemoveByTypeID(this, BulletsTypeID);

        return true;
    }
}
