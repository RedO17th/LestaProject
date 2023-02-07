using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public class HealEffect
{
    public int DisesAmount;
    public Dice Dice;
    public int Bonus;
}

[Serializable]
public class UsableItem : InventoryItem, IUsableItem
{
    public List<HealEffect> HealsEffects { get; }

    public UsableItem(UsableItemInfo itemInfo):base(itemInfo)
    {
        _itemInfo = itemInfo;
        HealsEffects = itemInfo.HealEffects;
    }

    public override IInventoryItem Clone()
    {
        var clonnedItem = new UsableItem((UsableItemInfo)ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }

    public void Use()
    {
        string info = $"������������ {ItemInfo.Title}.\n";
        foreach (var healEffect in HealsEffects)
        {
            int roll = DiceRoller.Roll(healEffect.Dice, healEffect.DisesAmount);
            int heal = roll + healEffect.Bonus;
            info += $"�������� �������������: {heal} ({healEffect.DisesAmount}{healEffect.Dice}+{healEffect.Bonus}).\n";
        }
        Debug.Log(info);
        InventoryController.Instance.Inventory.RemoveByTypeID(this, ItemInfo.TypeId);
    }
}
