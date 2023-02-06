using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ScreenNavigationButtonData))]
public class ScreenNavigationButton : BaseButton, IButtonWithData
{
    public IButtonData Data => _data;

    private ScreenNavigationButtonData _data = null;

    public void Initialize()
    {
        _data = GetComponent<ScreenNavigationButtonData>();
    }

    public override void Subscribe(UnityAction<BaseButton> listener)
    {
        onClick.AddListener(() => listener(this));
    }
}
