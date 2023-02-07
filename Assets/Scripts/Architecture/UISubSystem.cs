using UnityEngine;
using System.Collections.Generic;
using System;

public class UISubSystem : BaseSubSystem
{
    [Header("Screens")]
    [SerializeField] private Screen _HUDScreen = null;
    [SerializeField] private Screen _inventoryScreen = null;
    [SerializeField] private Screen _clipboardScreen = null;
    [SerializeField] private Screen _skillsScreen = null;
    [SerializeField] private Screen _pauseMenuScreen = null;
    [SerializeField] private Screen _dialogScreen = null;
    [SerializeField] private Screen _settingsScreen = null;
    private List<Screen> _screens = null;

    private bool _isInMenu = false;
    public bool IsInMenu => _isInMenu;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeScreens(); 
    }

    public override void StartSystem()
    {
        base.StartSystem();

        _isInMenu = false;
        ShowScreen(_HUDScreen.ID);
    }

    public void OnEnable()
    {
        EventSystem.UIEvents.OnScreenCalled += ShowScreen;

        EventSystem.UIEvents.OnPauseMenuCalled += HandleOnPauseMenuCalled;

        EventSystem.UIEvents.OnPlayerMenuExit += HandleOnPlayerMenuExit;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isInMenu)
            {
                Debug.Log("InvokeOnPlayerMenuExit");
                EventSystem.UIEvents.InvokeOnPlayerMenuExit();
            }
            else
            {
                Debug.Log("InvokeOnPauseMenuCalled");
                EventSystem.UIEvents.InvokeOnPauseMenuCalled();
            }
        }
    }

    private void InitializeScreens()
    {
        _screens = new List<Screen>();
        if (_HUDScreen != null) _screens.Add(_HUDScreen);
        if (_inventoryScreen != null) _screens.Add(_inventoryScreen);
        if (_clipboardScreen != null) _screens.Add(_clipboardScreen);
        if (_skillsScreen != null) _screens.Add(_skillsScreen);
        if (_dialogScreen != null) _screens.Add(_dialogScreen);
        if (_pauseMenuScreen != null) _screens.Add(_pauseMenuScreen);
        if (_settingsScreen != null) _screens.Add(_settingsScreen);
    }

    public void ShowScreen(ScreenID screenID)
    {
        if (screenID == _HUDScreen.ID && _isInMenu)
        {
            EventSystem.InvokeOnResumeCalled();
            _isInMenu = false;
        }
        else if (screenID != _HUDScreen.ID && !_isInMenu)
        {
            EventSystem.InvokeOnPauseCalled();
            _isInMenu = true;
        }
        
        foreach (Screen s in _screens)
        {
            if (s.ID == screenID)
            {
                s.ShowScreen();
            }
            else
                s.HideScreen();
        }
    }

    public void HandleOnPauseMenuCalled()
    {
        ShowScreen(_pauseMenuScreen.ID);
        EventSystem.InvokeOnPauseCalled();
    }

    public void HandleOnPlayerMenuExit()
    {
        ShowScreen(_HUDScreen.ID);
        EventSystem.InvokeOnResumeCalled();
    }

    public void OnDisable()
    {
        EventSystem.UIEvents.OnScreenCalled -= ShowScreen;

        EventSystem.UIEvents.OnPauseMenuCalled -= HandleOnPauseMenuCalled;

        EventSystem.UIEvents.OnPlayerMenuExit -= HandleOnPlayerMenuExit;
    }
}
