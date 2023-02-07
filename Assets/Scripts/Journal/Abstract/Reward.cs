using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reward
{
    [SerializeField] private int _experience;
    [SerializeField] private int _money;
    [SerializeField] private List<ItemData> _items;

    public int Experience => _experience;
    public int Money => _money;

    public List<ItemData> Items => _items;
}