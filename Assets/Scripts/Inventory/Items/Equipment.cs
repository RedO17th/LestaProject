using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Equipment : InventoryItem, IEquipment
{
    public List<CharacteristicBonus> EquipmentBonuses { get; }

    public EquipmentType EquipmentType { get; }

    public Equipment(EquipmentInfo itemInfo):base(itemInfo)
    {
        _itemInfo = itemInfo;
        EquipmentBonuses = itemInfo.EquipmentBonuses;
        EquipmentType = itemInfo.EquipmentType;
    }

    public override IInventoryItem Clone()
    {
        var clonnedItem = new Equipment((EquipmentInfo)ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }

    public virtual void Equip()
    {
        EnableEquipedBonus();
        State.isEquipped = true;
    }

    public virtual void UnEquip()
    {
        DisableEquipedBonus();
        State.isEquipped = false;
    }

    private void EnableEquipedBonus()
    {
        foreach (var bonus in EquipmentBonuses)
        {
            //Player.AddBonusToCharactericsic(bonus.Characteristic, bonus.Value);
            Debug.Log($"Добавлен бонус предмета {ItemInfo.Title} ({bonus.Value}) к {bonus.Characteristic}");
        }
    }

    private void DisableEquipedBonus()
    {
        foreach (var bonus in EquipmentBonuses)
        {
            //Player.RemoveBonusToCharactericsic(bonus.Characteristic, bonus.Value);
            Debug.Log($"Убран бонус предмета {ItemInfo.Title} ({bonus.Value}) к {bonus.Characteristic}");
        }
    }
}


