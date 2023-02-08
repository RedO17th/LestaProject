using UnityEngine;
using System.Collections.Generic;
using System;

public class UISubSystem : BaseSubSystem
{
    [Header("Screens")]
    [SerializeField] private IngameScreen _HUDScreen = null;
    [SerializeField] private IngameScreen _inventoryScreen = null;
    [SerializeField] private IngameScreen _clipboardScreen = null;
    [SerializeField] private IngameScreen _skillsScreen = null;
    [SerializeField] private IngameScreen _pauseMenuScreen = null;
    [SerializeField] private IngameScreen _dialogScreen = null;
    [SerializeField] private IngameScreen _settingsScreen = null;
    private List<IngameScreen> _screens = null;

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

        EventSystem.UIEvents.OnDialogueMenuCalled += HandleOnDialogueMenuCalled;

        EventSystem.UIEvents.OnExitFromDialogueMenuCalled += HandleOnExitFromDialogueMenuCalled;
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
        _screens = new List<IngameScreen>();
        if (_HUDScreen != null) _screens.Add(_HUDScreen);
        if (_inventoryScreen != null) _screens.Add(_inventoryScreen);
        if (_clipboardScreen != null) _screens.Add(_clipboardScreen);
        if (_skillsScreen != null) _screens.Add(_skillsScreen);
        if (_dialogScreen != null) _screens.Add(_dialogScreen);
        if (_pauseMenuScreen != null) _screens.Add(_pauseMenuScreen);
        if (_settingsScreen != null) _screens.Add(_settingsScreen);
    }

    public void ShowScreen(IngameScreenID screenID)
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
        
        foreach (IngameScreen s in _screens)
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
        //EventSystem.InvokeOnPauseCalled();
    }

    public void HandleOnPlayerMenuExit()
    {
        ShowScreen(_HUDScreen.ID);
        //EventSystem.InvokeOnResumeCalled();
    }

    public void HandleOnDialogueMenuCalled()
    {
        ShowScreen(_dialogScreen.ID);
    }

    public void HandleOnExitFromDialogueMenuCalled()
    {
        ShowScreen(_HUDScreen.ID);
    }

    public void OnDisable()
    {
        EventSystem.UIEvents.OnScreenCalled -= ShowScreen;

        EventSystem.UIEvents.OnPauseMenuCalled -= HandleOnPauseMenuCalled;

        EventSystem.UIEvents.OnPlayerMenuExit -= HandleOnPlayerMenuExit;

        EventSystem.UIEvents.OnDialogueMenuCalled -= HandleOnDialogueMenuCalled;
    }
}
