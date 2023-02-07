using UnityEngine;

[System.Serializable]
public class ItemData
{
    [SerializeField] private InventoryItemInfo _info;
    [SerializeField] private int _amount;

    public InventoryItemInfo Info => _info;
    public int Amount => _amount;
}