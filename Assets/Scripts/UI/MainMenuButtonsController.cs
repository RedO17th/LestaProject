using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtonsController : OLDBaseUIController
{
    [SerializeField] private CommonButton _newGameButton = null;
    [SerializeField] private CommonButton _loadGameButton = null;
    [SerializeField] private CommonButton _settingsButton = null;
    [SerializeField] private CommonButton _creditsButton = null;
    [SerializeField] private CommonButton _exitButton = null;

    public static event Action<MainMenuScreenID> OnScreenFromMainCalled;

    public void Start()
    {
        PrepareButons();
    }

    private void PrepareButons()
    {
        _newGameButton.Subscribe(StartNewGame);
        _loadGameButton.Subscribe(LoadGame);
        _settingsButton.Subscribe(ShowSettingsScreen);
        _creditsButton.Subscribe(ShowCreditsScreen);
        _exitButton.Subscribe(Exit);
    }


    private void StartNewGame(OLDBaseButton listener)
    {
        OnScreenFromMainCalled?.Invoke(MainMenuScreenID.NewGameScreen);
    }


    private void LoadGame(OLDBaseButton listener)
    {
        SceneManager.LoadScene(1);
    }


    private void ShowSettingsScreen(OLDBaseButton listener)
    {
        OnScreenFromMainCalled?.Invoke(MainMenuScreenID.Settings);
    }


    private void ShowCreditsScreen(OLDBaseButton listener)
    {
        OnScreenFromMainCalled?.Invoke(MainMenuScreenID.Credits);
    }


    private void Exit(OLDBaseButton listener)
    {
        Application.Quit();
        Debug.Log("Чат летит так быстро, что никто не узнает, что я никогда не выведусь ибо я лог после блять выхода...");
    }
}
