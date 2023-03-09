using System;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuWindow : BaseWindow, IHaveButtons
{
    [Header("Кнопки навигации")] 
    [SerializeField] private CommonButtonWrapper _newGameButton = null;
    [SerializeField] private CommonButtonWrapper _loadGameButton = null;
    [SerializeField] private CommonButtonWrapper _settingsButton = null;
    [SerializeField] private CommonButtonWrapper _creditsButton = null;
    [SerializeField] private CommonButtonWrapper _exitButton = null;

    private List<CommonButtonWrapper> _buttons = null;

    public void OnEnable()
    {
        InitializeButtonsList();
        SubscribeToButtonsEvents();
        AddNavigationPair(_newGameButton, nameof(CharacterCreationWindow));
        AddNavigationPair(_loadGameButton, nameof(LoadGameWindow));
        AddNavigationPair(_settingsButton, nameof(SettingsWindow));
        AddNavigationPair(_creditsButton, nameof(CreditsWindow));

    }


    public void InitializeButtonsList()
    {
        _buttons = new List<CommonButtonWrapper>();
        if (_newGameButton != null) _buttons.Add(_newGameButton);
        if (_loadGameButton != null) _buttons.Add(_loadGameButton);
        if (_settingsButton != null) _buttons.Add(_settingsButton);
        if (_creditsButton != null) _buttons.Add(_creditsButton);
        if (_exitButton != null) _buttons.Add(_exitButton);
    }


    public void SubscribeToButtonsEvents()
    {
        foreach (var button in _buttons)
        {
            button.OnButtonClicked += HandleOnButtonClicked;
        }
    }


    public void UnsubscribeToButtonsEvents()
    {
        foreach (var button in _buttons)
        {
            button.OnButtonClicked -= HandleOnButtonClicked;
        }
    }

    private void HandleOnButtonClicked(IButtonWrapper clickedButton)
    {
        if ((CommonButtonWrapper)clickedButton == _exitButton)
        {
            Application.Quit();
        }
        string calledScreenTypeName = string.Empty;
        if (_navigationButtonsScreenPair.TryGetValue(clickedButton, out calledScreenTypeName))
        {
            EventSystem.UIEvents.InvokeOnWindowCalled(calledScreenTypeName, this);
        }

    }


    public void OnDisable()
    {
        UnsubscribeToButtonsEvents();
    }


}
