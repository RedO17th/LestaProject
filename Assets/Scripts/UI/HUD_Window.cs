using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Window : BaseWindow
{
    [SerializeField] private BaseUIController[] _controllers = null;

    public override void Initialize()
    {
        InitializeControllers();
    }

    private void InitializeControllers()
    {
        foreach (var controller in _controllers)
            controller.Initialize(this);
    }

}
