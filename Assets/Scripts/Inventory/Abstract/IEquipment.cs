using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment : IInventoryItem
{
    List<CharacteristicBonus> EquipmentBonuses { get; }

    EquipmentType EquipmentType { get; }

    public void Equip();

    public void UnEquip();
}