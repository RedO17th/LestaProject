using UnityEngine;

public class MainMenuScreen : BaseScreen 
{
    [SerializeField] private MainMenuScreenID _id = MainMenuScreenID.Default;

    public MainMenuScreenID ID => _id;
}


public enum MainMenuScreenID
{
    Default = -1,
    MainScreen = 0,
    NewGameScreen = 1,
    LoadChoice = 2,
    Settings = 3,
    Credits = 4
}
