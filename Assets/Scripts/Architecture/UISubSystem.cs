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

    private List<Screen> _PlayerMenuScreensOrder = null;
    
    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeModalScreens();

        InitializePlayerMenuScreensOrder();
    }

    public void Awake()
    {
        EventSystem.OnClipboardScreenCalled += HandleOnClipboardScreenCalled;
        EventSystem.OnInventoryScreenCalled += HandleOnInventoryScreenCalled;
        EventSystem.OnAbilitiesScreenCalled += HandleOnAbilitiesScreenCalled;
        
        EventSystem.OnPlayerMenuExit += HandleOnPlayerMenuExit;

        
    }

    public void Start()
    {
        ShowScreen(_HUDScreen);
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

    private void InitializePlayerMenuScreensOrder()
    {
        _PlayerMenuScreensOrder = new List<Screen>();
        if (_clipboardScreen != null) _PlayerMenuScreensOrder.Add(_clipboardScreen);
        if (_inventoryScreen != null) _PlayerMenuScreensOrder.Add(_inventoryScreen);
        if (_abilitiesScreen != null) _PlayerMenuScreensOrder.Add(_abilitiesScreen);
    }

    private void ShowScreen(Screen screen)
    {
        foreach (Screen s in _modalScreens)
        {
            if (s == screen)
                s.ShowScreen();
            else
                s.HideScreen();
        }
    }

    public void HandleOnClipboardScreenCalled()
    {
        ShowScreen(_clipboardScreen);
    }

    public void HandleOnInventoryScreenCalled()
    {
        ShowScreen(_inventoryScreen);
    }

    public void HandleOnAbilitiesScreenCalled()
    {
        ShowScreen(_abilitiesScreen);
    }

    public void HandleOnPauseMenuScreenCalled()
    {
        ShowScreen(_pauseMenuScreen);
    }

    public void HandleOnPlayerMenuExit()
    {
        ShowScreen(_HUDScreen);
    }

    public void Destroy()
    {
        EventSystem.OnClipboardScreenCalled -= HandleOnClipboardScreenCalled;
        EventSystem.OnInventoryScreenCalled -= HandleOnInventoryScreenCalled;
        EventSystem.OnAbilitiesScreenCalled -= HandleOnAbilitiesScreenCalled;

        EventSystem.OnPlayerMenuExit -= HandleOnPlayerMenuExit;
    }
}
