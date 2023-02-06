using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class NavigationPanelUIController : BaseUIController
{
    public static event Action OnScreenCalled = null;
    
    [SerializeField] private ScreenNavigationButton[] _navButtons = null;
    
    public void Awake()
    {
        PrepareButons();
    }

    private void PrepareButons()
    {
        foreach (ScreenNavigationButton b in _navButtons)
        {
            b.Initialize();
            b.Subscribe(NavButtonClickListener);
        }
    }
    
    private void NavButtonClickListener(BaseButton sender)
    {
        if (sender is ScreenNavigationButton s)
        {
            if (s.Data is ScreenNavigationButtonData d)
            {
                EventSystem.InvokeOnScreenCalled(d.ScreenID);
            }
        }
    }
}


