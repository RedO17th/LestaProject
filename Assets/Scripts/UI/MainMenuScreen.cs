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
    LoadChoice = 1,
    Settings = 2,
    Credits = 3
}
