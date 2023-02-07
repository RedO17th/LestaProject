using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSlot : MonoBehaviour
{
    [SerializeField] private UIQuickAccessMenuItem _item;
    [SerializeField] private InventoryItemInfo _ammoInfo;

    void Start()
    {
        Ammo ammo = new Ammo(_ammoInfo);
        _item.SetNewItem(ammo);
    }
}
