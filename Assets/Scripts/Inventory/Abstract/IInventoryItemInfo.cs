using System;
using UnityEngine;

public interface IInventoryItemInfo
{
    string TypeId { get; }
    string Title { get; }
    string Description { get; }
    int MaxItemsInInventorySlot { get; }
    int Price { get; }
    Sprite SpriteIcon { get; }
}
