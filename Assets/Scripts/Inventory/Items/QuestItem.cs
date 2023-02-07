using System;
using UnityEngine;

[Serializable]
public class QuestItem : InventoryItem
{
   public QuestItem(IInventoryItemInfo itemInfo) :base(itemInfo)
   {

   }

    public override IInventoryItem Clone()
    {
        var clonnedItem = new QuestItem(ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }
}
