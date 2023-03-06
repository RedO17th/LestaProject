using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ScreenNavigationButtonData))]
public class ScreenNavigationButton : OLDBaseButton, IButtonWithData
{
    public IButtonData Data => _data;

    private ScreenNavigationButtonData _data = null;

    public void Initialize()
    {
        _data = GetComponent<ScreenNavigationButtonData>();
    }

    public override void Subscribe(UnityAction<OLDBaseButton> listener)
    {
        onClick.AddListener(() => listener(this));
    }
}
