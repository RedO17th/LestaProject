using System;
using UnityEngine;

public class MainMenuUIController : BaseUIController
{
    public override void Start()
    {
        base.Start();
        ShowWindow(nameof(MainMenuWindow));
    }
}
