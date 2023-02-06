using UnityEngine;
using System.Collections.Generic;

/*
 * По сути, всё, что делает подсистема - может выполнять некий UIManager
 * Понятия не имею за что эти системы должны быть ответственны в принципе.
 */

public class UISubSystem : BaseSubSystem
{
    [Header("Screens")]
    [SerializeField] private Screen _HUDScreen = null;
    [SerializeField] private Screen _inventoryScreen = null;
    [SerializeField] private Screen _clipboardScreen = null;
    [SerializeField] private Screen _abilitiesScreen = null;
    [SerializeField] private Screen _pauseMenuScreen = null;
    
    [SerializeField] private Screen _dialogScreen = null;
    
    [SerializeField] private Screen _tooltipScreen = null;

    private List<Screen> _modalScreens = null;
    
    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeModalScreens();
    }

    public void Awake()
    {
        EventSystem.OnScreenCalled += HandleOnScreenCalled;
        
        EventSystem.OnPlayerMenuExit += HandleOnPlayerMenuExit;  
    }

    public void Start()
    {
        ShowScreen(_HUDScreen.ScreenID);
    }

    private void InitializeModalScreens()
    {
        _modalScreens = new List<Screen>();
        if (_HUDScreen != null) _modalScreens.Add(_HUDScreen);
        if (_inventoryScreen != null) _modalScreens.Add(_inventoryScreen);
        if (_clipboardScreen != null) _modalScreens.Add(_clipboardScreen);
        if (_abilitiesScreen != null) _modalScreens.Add(_abilitiesScreen);
        if (_dialogScreen != null) _modalScreens.Add(_dialogScreen);
    }

    private void ShowScreen(string screenID)
    {
        foreach (Screen s in _modalScreens)
        {
            if (s.ScreenID == screenID)
                s.ShowScreen();
            else
                s.HideScreen();
        }
    }

    public void HandleOnScreenCalled(string screenID)
    {
        ShowScreen(screenID);
    }

    public void HandleOnPlayerMenuExit()
    {
        ShowScreen(_HUDScreen.ScreenID);
    }

    public void Destroy()
    {
        EventSystem.OnScreenCalled -= HandleOnScreenCalled;

        EventSystem.OnPlayerMenuExit -= HandleOnPlayerMenuExit;
    }
}
