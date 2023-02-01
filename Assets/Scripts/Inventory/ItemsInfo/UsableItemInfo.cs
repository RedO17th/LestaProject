using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UsableItemInfo", menuName = "Gameplay/Items/Create New UsableItemInfo")]
public class UsableItemInfo : InventoryItemInfo
{
    [SerializeField] private List<HealEffect> _healEffects;

    public List<HealEffect> HealEffects => _healEffects;
}
