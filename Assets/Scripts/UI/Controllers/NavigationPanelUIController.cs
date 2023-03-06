using System;
using UnityEngine;


public class NavigationPanelUIController : OLDBaseUIController
{    
    [SerializeField] private ScreenNavigationButton[] _navButtons = null;
    
    public void Start()
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
    
    private void NavButtonClickListener(OLDBaseButton sender)
    {
        if (sender is ScreenNavigationButton s)
        {
            if (s.Data is ScreenNavigationButtonData d)
            {
                EventSystem.OLDUIEvents.InvokeOnScreenCalled(d.ID);
            }
        }
    }
}


