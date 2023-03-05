using UnityEngine;
using System.Collections.Generic;
using System;
using SaveAndLoadModule;

public class UISubSystem : BaseSubSystem, ILoader
{
    [SerializeField] private UIContainer _uiContainer = null;

    public UIContainer UIContainer => _uiContainer;

    private IngameScreen _HUDScreen = null;
    private IngameScreen _inventoryScreen = null;
    private IngameScreen _clipboardScreen = null;
    private IngameScreen _skillsScreen = null;
    private IngameScreen _pauseMenuScreen = null;
    private IngameScreen _dialogueScreen = null;
    private IngameScreen _settingsScreen = null;
    private List<IngameScreen> _screens = null;

    private bool _isInMenu = false;
    public bool IsInMenu => _isInMenu;

    public override void Initialize()
    {
        InitializeScreens(); 
    }

    private void InitializeScreens()
    {
        _screens = new List<IngameScreen>();

        _HUDScreen = _uiContainer.HUDScreen;
        _inventoryScreen = _uiContainer.InventoryScreen;
        _clipboardScreen = _uiContainer.ClipboardScreen;
        _skillsScreen = _uiContainer.SkillsScreen;
        _pauseMenuScreen = _uiContainer.PauseMenuScreen;
        _dialogueScreen = _uiContainer.DialogueScreen;
        _settingsScreen = _uiContainer.SettingsScreen;

        if (_HUDScreen != null) _screens.Add(_HUDScreen);
        if (_inventoryScreen != null) _screens.Add(_inventoryScreen);
        if (_clipboardScreen != null) _screens.Add(_clipboardScreen);
        if (_skillsScreen != null) _screens.Add(_skillsScreen);
        if (_dialogueScreen != null) _screens.Add(_dialogueScreen);
        if (_pauseMenuScreen != null) _screens.Add(_pauseMenuScreen);
        if (_settingsScreen != null) _screens.Add(_settingsScreen);
    }

    public void Load()
    {
        Debug.Log($"UISubSystem.Load");
    }

    public override void StartSystem()
    {
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

    public void ShowScreen(IngameScreenID screenID)
    {
        if ((screenID == _HUDScreen.ID) && _isInMenu)
        {
            EventSystem.InvokeOnResumeCalled();
            _isInMenu = false;
        }
        else if ((screenID != _HUDScreen.ID && screenID != _dialogueScreen.ID) && !_isInMenu)
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
    }

    public void HandleOnPlayerMenuExit()
    {
        ShowScreen(_HUDScreen.ID);
    }

    public void HandleOnDialogueMenuCalled()
    {
        ShowScreen(_dialogueScreen.ID);
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
