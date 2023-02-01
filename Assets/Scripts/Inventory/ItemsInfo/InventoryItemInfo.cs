using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemInfo" , menuName = "Gameplay/Items/Create New ItemInfo")]
public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
{
    [SerializeField] private string _typeId;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _price;
    [Range(1, 25)]
    [SerializeField] private int _maxItemsInInventorySlot;
    [SerializeField] private Sprite _spriteIcon;

    public string TypeId => _typeId;

    public string Title => _title;

    public string Description => _description;

    public int Price => _price;

    public int MaxItemsInInventorySlot => _maxItemsInInventorySlot;

    public Sprite SpriteIcon => _spriteIcon;
}
