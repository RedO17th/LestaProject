using System;
using UnityEngine;


public class NavigationPanelUIController : BaseUIController
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
    
    private void NavButtonClickListener(BaseButton sender)
    {
        if (sender is ScreenNavigationButton s)
        {
            if (s.Data is ScreenNavigationButtonData d)
            {
                EventSystem.UIEvents.InvokeOnScreenCalled(d.ID);
            }
        }
    }
}


