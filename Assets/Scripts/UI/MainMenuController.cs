using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private MainMenuScreen _mainScreen = null;
    [SerializeField] private MainMenuScreen _characterCreationScreen = null;
    [SerializeField] private MainMenuScreen _loadChoiceScreen = null;
    [SerializeField] private MainMenuScreen _settingsScreen = null;
    [SerializeField] private MainMenuScreen _creditsScreen = null;
    private List<MainMenuScreen> _screens = null;

    [SerializeField] private CommonButton[] _toMainButtons = null;

    public void Start()
    {
        InitializeScreens();
        InitializeToMainButtons();
        MainMenuButtonsController.OnScreenFromMainCalled += ShowScreen;
        ShowScreen(MainMenuScreenID.MainScreen);
    }

    private void InitializeScreens()
    {
        _screens = new List<MainMenuScreen>();
        if (_mainScreen != null) _screens.Add(_mainScreen);
        if (_characterCreationScreen != null) _screens.Add(_characterCreationScreen);
        if (_loadChoiceScreen != null) _screens.Add(_loadChoiceScreen);
        if (_settingsScreen != null) _screens.Add(_settingsScreen);
        if (_creditsScreen != null) _screens.Add(_creditsScreen);
    }


    private void InitializeToMainButtons()
    {
        foreach(var b in _toMainButtons)
        {
            b.Subscribe((BaseButton b) => ShowScreen(MainMenuScreenID.MainScreen));
        }
    }


    public void ShowScreen(MainMenuScreenID screenID)
    {
        foreach (MainMenuScreen s in _screens)
        {
            if (s.ID == screenID)
                s.ShowScreen();
            else
                s.HideScreen();
        }
    }
}



