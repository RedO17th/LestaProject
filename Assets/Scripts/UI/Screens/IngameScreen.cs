using System;
using UnityEngine;
using static UISubSystem;

public class IngameScreen : BaseScreen
{
    [SerializeField] private IngameScreenID _id = IngameScreenID.Default;

    public IngameScreenID ID => _id;
}


public enum IngameScreenID
{
    Default = -1,
    HUD = 0,
    Inventory = 1,
    Journal = 2,
    Skills = 3,
    PauseMenu = 4,
    Dialogue = 5,
    Settings = 6
}


