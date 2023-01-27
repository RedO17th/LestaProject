using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_XVisionButton_Controller : BaseUIController
{
    public event Action OnXVisionCalled = null;

    [SerializeField] private HUD_Button _XVisionButton = null;

    public override void Initialize(BaseWindow window)
    {
        base.Initialize(window);

        InitializeButtons();
    }


    private void InitializeButtons()
    {
        _XVisionButton?.Initialize(OnXVisionButtonClicked);
    }


    private void OnXVisionButtonClicked()
    {
        OnXVisionCalled?.Invoke();
    }


}
