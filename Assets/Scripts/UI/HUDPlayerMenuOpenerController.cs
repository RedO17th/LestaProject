using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class HUDPlayerMenuOpenerController : BaseUIController
{
    public static event Action OnClipboardScreenCalled = null;
    public static event Action OnInventoryScreenCalled = null;
    
    [SerializeField] private BaseButton _clipboardButton = null;
    [SerializeField] private BaseButton _skillsButton = null;
    
    public void Awake()
    {
        PrepareSubordinates();
    }

    private void PrepareSubordinates()
    {
        _clipboardButton?.Initialize(ClippboardMenuButtonClickListener);
        _skillsButton?.Initialize(InventoryButtonClickListener);
    }

    private void ClippboardMenuButtonClickListener()
    {
        EventSystem.InvokeOnClipboardScreenCalled();
        Debug.Log("class: HUDPlayerMenuOpenerController\nmethod: ClippboardMenuButtonClickListener");
    }
    
    private void InventoryButtonClickListener()
    {
        EventSystem.InvokeOnInventoryScreenCalled();
        Debug.Log("class: HUDPlayerMenuOpenerController\nmethod: InventoryButtonClickListener");
    }
}
