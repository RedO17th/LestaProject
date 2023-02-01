using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentInfo", menuName = "Gameplay/Items/Create New EquipmentInfo")]
public class EquipmentInfo : InventoryItemInfo
{
    [SerializeField] private List<CharacteristicBonus> _equipmentBonuses;
    [SerializeField] private EquipmentType _equipmentType;

    public List<CharacteristicBonus> EquipmentBonuses => _equipmentBonuses;
    public EquipmentType EquipmentType => _equipmentType;
}
